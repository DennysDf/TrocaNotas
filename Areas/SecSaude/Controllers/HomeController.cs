using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SecSaudeAH.Areas.SecSaudeAH.Models.Home;
using SecSaudeAH.Models.BDSECSAUDE.Context;
using SecSaudeAH.Models.Login;
using SecSaudeAH.Services.Interfaces;

namespace SecSaudeAH.Areas.SecSaudeAH.Controllers
{
    [Authorize]
    [Area("SecSaude")]
    public class HomeController : Controller
    {
        private readonly IUser _user;
        private readonly DBSaudeAHContext _context;
        private readonly INotificacao _notify;
        private readonly IUpload _upload;
        public IHttpContextAccessor _http { get; set; }

        public HomeController(IUser user, DBSaudeAHContext context, INotificacao notify, IUpload upload, IHttpContextAccessor http)
        {
            _user = user;
            _context = context;
            _notify = notify;
            _upload = upload;
            _http = http;
        }

        public IActionResult Index()
        {
            ViewData["QtdClientes"] = _context.Pacientes.Include(c => c.Profissional).Where(c => c.CNS == null && c.NomeMae == null && c.IsAtivo).Count();

            ViewData["QtdNotas"] = _context.NotaFiscais.Where(c => c.IsAtivo).Count();

            ViewData["QtdValor"] = _context.NotaFiscais.Where(c => c.IsAtivo).Select(c => new { c.Valor }).Sum(c => c.Valor);

            ViewData["QtdIngressos"] = _context.Trocas.Where(c => c.IsAtivo).Count();

            return View();
        }

        public IActionResult Perfil()
        {
            var cliente = _context.Profissionais
                .Include(c => c.Secretaria)
                .Where(c => c.Id == _user.Id)
                .Select(c => new PerfilVM
                {
                    Id = c.Id,
                    Nome = c.Nome,
                    Email = c.Email,                                        
                    Telefone = c.Telefone
                })
                .First();

            //var cli = TempData["Filtro"] != null ? JsonConvert.DeserializeObject<PerfilVM>(TempData["Filtro"].ToString()) : cliente;

            return View(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> Perfil(PerfilVM model, IFormFile Foto)
        {


            var direitorio = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Upload\\Usuarios");

            var user = _context.Profissionais.Include(c => c.Secretaria).First(c => c.Id == _user.Id);

            if (model.SenhaN != null && model.Senha == null)
            {
                TempData["Filtro"] = JsonConvert.SerializeObject(model);
                TempData["MensagemSenhaAtual"] = "Para atualizar a senha digite a senha atual.";
                return RedirectToAction("Perfil");
            }

            var senha = model.Senha != null ? model.Senha : user.Senha;

            if (senha != user.Senha)
            {
                TempData["Filtro"] = JsonConvert.SerializeObject(model);
                TempData["MensagemSenhaAtual"] = "Senha não coincide com a senha atual.";
                return RedirectToAction("Perfil");
            }

            if (Foto != null && user.Extensao != null)
            {
                _upload.Delete(direitorio, $"{user.Id}_{user.Extensao}");
                user.Extensao = null;
            }

            if (Foto != null)
            {
                _upload.Save(direitorio, Foto, _user.Id);
                user.Extensao = Path.GetFileName(Foto.FileName);
            }


            user.Nome = model.Nome;
            user.Email = model.Email;
            user.Telefone = model.Telefone;
            if (model.SenhaN != null)
                user.Senha = model.SenhaN;
            _context.Update(user);

        

            var createCookies = new CreateCookies(_http);
            await createCookies.Autenticar(user);

            _context.SaveChanges();
            _notify.Success("Perfil atualizado com sucesso.");

            return RedirectToAction("Index");
        }

        public bool ValidaSenha(string senha)
        {
            var senhaAtual = _context.Profissionais.First(c => c.Id == _user.Id).Senha;

            return senhaAtual == senha;

        }
    }
}