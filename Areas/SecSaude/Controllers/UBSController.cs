using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecSaudeAH.Areas.SecSaude.Models.UBS;
using SecSaudeAH.Areas.SecSaude.Models.Unidades;
using SecSaudeAH.Models.BDSECSAUDE.Context;
using SecSaudeAH.Services.Interfaces;

namespace SecSaudeAH.Areas.SecSaude.Controllers
{

    [Authorize]
    [Area("SecSaude")]
    public class UBSController : Controller
    {
        private readonly DBSaudeAHContext _context;
        private readonly IUser _user;
        private readonly INotificacao _notify;

        public UBSController(DBSaudeAHContext context, IUser user, INotificacao notidy)
        {
            _context = context;
            _user = user;
            _notify = notidy;
        }



        public IActionResult Index()
        {
            //TIPO 1 = HOSPITAL, CLINICAS
            var unidades = _context.Unidades.Where(c => c.IsAtivo && c.Tipo == 2).Select(c => new UnidadesVM
            {
                Id = c.Id,
                Nome = c.Nome,
                Endereco = c.Endereco,
                Telefone = c.Telefone
            }).ToList();

            return View(unidades);
        }

        [HttpPost]
        public IActionResult Index(UnidadesVM model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    _context.Add(model.Insert(_user.Id, model.Tipo));
                    _context.SaveChanges();
                    _notify.Success("UBS cadastrado com sucesso.");
                }
                else
                {
                    _context.Update(model.Update(_context, model.Id));
                    _context.SaveChanges();
                    _notify.Success("UBS editado com sucesso.");
                }
            }
            else
            {
                _notify.Error();
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Ajax(int id = 0)
        {
            if (id == 0)
                return View(new UnidadesVM());
            else
                return View(new UnidadesVM(_context, id));
        }

        public IActionResult Delete(int id)
        {
            var unidade = _context.Unidades.FirstOrDefault(c => c.Id == id);
            unidade.IsAtivo = false;
            _context.Update(unidade);
            _context.SaveChanges();
            _notify.Success("UBS apagada com sucesso.");

            return RedirectToAction(nameof(Index));
        }


    }
}