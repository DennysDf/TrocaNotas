using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecSaudeAH.Areas.SecSaude.Models.Procedimentos;
using SecSaudeAH.Models.BDSECSAUDE.Context;
using SecSaudeAH.Services.Interfaces;

namespace SecSaudeAH.Areas.SecSaude.Controllers
{
    [Authorize]
    [Area("SecSaude")]
    public class ProcedimentosController : Controller
    {
        private readonly DBSaudeAHContext _context;
        private readonly IUser _user;
        private readonly INotificacao _notify;

        public ProcedimentosController(DBSaudeAHContext context, IUser user, INotificacao notify)
        {
            _context = context;
            _user = user;
            _notify = notify;
        }

        public IActionResult Index()
        {
            var procedimentos = _context.Procedimentos.Where(c => c.IsAtivo).Select(c => new ProcedimentosVM
            {
                Id = c.Id,
                Nome = c.Nome,
                Valor = c.ValorMed,
                TipoText = c.Tipo == 1 ? "Consulta" : c.Tipo == 2 ? "Exame" : "Cirurgia"
            }).ToList();

            return View(procedimentos);
        }

        [HttpPost]
        public IActionResult Index(ProcedimentosVM model)
        {

            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    _context.Add(model.Insert(_user.Id));
                    _context.SaveChanges();
                    _notify.Success("Procedimento cadastrado com sucesso.");
                }
                else
                {
                    _context.Update(model.Update(_context, model.Id));
                    _context.SaveChanges();
                    _notify.Success("Procedimento editado com sucesso.");
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
                return View(new ProcedimentosVM());
            else
                return View(new ProcedimentosVM(_context, id));
        }

        public IActionResult Delete(int id)
        {
            var procedimento = _context.Procedimentos.FirstOrDefault(c => c.Id == id);
            procedimento.IsAtivo = false;
            _context.Update(procedimento);
            _context.SaveChanges();
            _notify.Success("Procedimento apagado com sucesso.");

            return RedirectToAction(nameof(Index));
        }

    }
}