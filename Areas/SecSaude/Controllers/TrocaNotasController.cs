using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SecSaudeAH.Areas.SecSaude.Models.Pacientes;
using SecSaudeAH.Areas.SecSaude.Models.TrocasNotas;
using SecSaudeAH.Models.BDSECSAUDE.Context;
using SecSaudeAH.Models.BDSECSAUDE.Entidades;
using SecSaudeAH.Services.Interfaces;

namespace SecSaudeAH.Areas.SecSaude.Controllers
{
    [Authorize]
    [Area("SecSaude")]
    public class TrocaNotasController : Controller
    {
        private readonly DBSaudeAHContext _context;
        private readonly IUser _user;
        private readonly INotificacao _notify;
        private readonly IUpload _upload;

        public TrocaNotasController(DBSaudeAHContext context, IUser user, INotificacao notidy, IUpload upload)
        {
            _context = context;
            _user = user;
            _notify = notidy;
            _upload = upload;
        }


        public IActionResult Index()
        {
            var pacientes = _context.Pacientes.Where(c => c.IsAtivo).Select(c => new TrocaNotasVM
            {
                Id = c.Id,
                Nome = c.Nome,
                Endereco = c.Endereco,
                CPF = c.CPF,
                IsAtivo = c.IsAtivo,
                DataNasc = c.DataNasc,
                Telefone = c.Telefone
            }).ToList();


            return View(pacientes);
        }

        [HttpPost]
        public IActionResult Index(TrocaNotasVM model)
        {

            if (ModelState.IsValid)
            {
                var cidadao = new Paciente();
                if (model.Id == 0)
                {
                    cidadao = model.Insert(_user.Id);
                    _context.Add(cidadao);
                    _context.SaveChanges();
                    _notify.Success("Cidadão cadastrado com sucesso.");
                }
                else
                {
                    cidadao = model.Update(_context, model.Id);
                    _context.Update(cidadao);
                    _context.SaveChanges();
                    _notify.Success("Cidadão editado com sucesso.");
                }
                return RedirectToAction(nameof(Notas), new { id = cidadao.Id });
            }
            else
            {
                _notify.Error();
                return View();
            }            
        }

        public IActionResult Ajax(int id = 0)
        {
            if (id == 0)
                return View(new TrocaNotasVM());
            else
                return View(new TrocaNotasVM(_context, id));
        }

        public IActionResult Notas(int id)
        {

            var ingresso = new Ingresso();

            var cidadao = _context.Pacientes.Where(c => c.Id == id)
                .Select(c => new NotaFiscaisVM
                {                   
                    Nome = c.Nome,
                    Telefone = c.Telefone,
                    DataNasc = c.DataNasc,
                    Endereco = c.Endereco
                }).First();

            var notas = _context.NotaFiscais.Where(c => c.IdCidadao == id)
                .Select(c => new NotaFiscaisVM { Id = c.Id , CNPJ = c.CNPJ, NumNota = c.Numero, ValorS = c.Valor.ToString(), Valor = c.Valor, NomeArquivo = c.NomeArquivo, FotoEndereco = $"{c.Id}_{c.NomeArquivo}" })
                .ToList();

            var saldo = notas.Sum(c => c.Valor) -  (_context.Trocas.Where(c => c.CidadaoId == id).Any() ? _context.Trocas.Where(c => c.CidadaoId == id).Select(c => c.Valor).Sum() : 0);


            var trocas = _context.Trocas
                .Where(c => c.CidadaoId == id && c.IsAtivo)
                .Select(c => new TrocaIngresso { 
                    IdTroca = c.Id , 
                    DataTroca = c.Data 
                }).ToList();

       

            


            ViewData["Saldo"] = saldo;
            ViewData["Nome"] = cidadao.Nome ;
            ViewData["Telefone"] = cidadao.Telefone;
            ViewData["DataNasc"] = cidadao.DataNasc;
            ViewData["Endereco"] = cidadao.Endereco;
            ViewData["IdCidadao"] = id;

            ingresso.Notas = notas;
            ingresso.Trocas = trocas;

            return View(ingresso);
        }

        public IActionResult AjaxNotas(int id = 0) 
        {


            return View();
        }

        [HttpPost]
        public IActionResult Notas(NotaFiscaisVM model)
        {            

            if (model.Id == 0)
            {                
                var nota = model.Insert(_user.Id);
                nota.IdCidadao = model.IdCidadao;
                nota.NomeArquivo = model.Foto != null ? Path.GetFileName(model.Foto.FileName) : null;
                nota.Valor = decimal.Parse(model.ValorS.Replace(".", "").Replace(",", "."));  

                _context.Add(nota);
                _context.SaveChanges(); 

                var diretorio = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\Upload\\Notas\\{nota.IdCidadao}");

                if (model.Foto != null)
                {
                    _upload.Save(diretorio, model.Foto, nota.Id);
                }

                    
                _notify.Success("Nota fiscal cadastrada com sucesso.");
            }
            else
            {
                //_context.Update(model.Update(_context, model.Id));
                //_context.SaveChanges();
                //_notify.Success("Cidadão editado com sucesso.");
            }
            //}
            //else
            //{
            //    _notify.Error();
            //}








            //var direitorio = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Upload\\Notas");


            //if (model.Foto != null)

            //    if (cliente.Extensao != null)
            //        _upload.Delete(direitorio, $"{id}_{cliente.Extensao}");

            //    _upload.Save(direitorio, model.Foto, cliente.Id);
            //    cliente.Extensao = Path.GetFileName(model.Foto.FileName);
            //}


            return RedirectToAction(nameof(Notas), new { id = model.IdCidadao });


        }

        public bool VerificaNumNota (int num, string CNPJ) =>_context.NotaFiscais.Where(c => Int32.Parse(c.Numero) == num && c.CNPJ.Equals(CNPJ)).Any();

        public IActionResult TrocarIngresso(int id) 
        {
            var saldo = _context.NotaFiscais.Where(c => c.IdCidadao == id).Select(c => c.Valor).Sum();

            

            if (saldo >= 500)
            {
                var troca = new TrocarPorIngresso { Valor = 500, CidadaoId = id, ProfissionalId = _user.Id, Data = $"{DateTime.Now.Day}/{DateTime.Now.Month}/{DateTime.Now.Year}"  };
                _context.Add(troca);
                _context.SaveChanges();
                _notify.Success("Troca realizada com sucesso.");
            }
            else
            {
                _notify.Error();
            }


            return RedirectToAction(nameof(Notas), new { id = id });
        }

        public IActionResult AjaxEvento()
        {
            var eventos = _context.Eventos.Where(c=> c.IsAtivo).ToList();

            return View();
        }

    }
}
