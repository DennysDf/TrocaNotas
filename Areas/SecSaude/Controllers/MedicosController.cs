using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecSaudeAH.Areas.SecSaude.Models.MedicoVM;
using SecSaudeAH.Models.BDSECSAUDE.Context;
using SecSaudeAH.Services.Interfaces;

namespace SecSaudeAH.Areas.SecSaude.Controllers
{
    [Authorize]
    [Area("SecSaude")]
    public class MedicosController : Controller
    {
        private readonly DBSaudeAHContext _context;
        private readonly IUser _user;
        private readonly INotificacao _notify;

        public MedicosController(DBSaudeAHContext context, IUser user, INotificacao notidy)
        {
            _context = context;
            _user = user;
            _notify = notidy;
        }


        public IActionResult Index()
        {
            var medicos = _context.Medicos.Where(c => c.IsAtivo).Select(c => new MedicosVM
            {
                Id = c.Id,
                Nome = c.Nome,
                CRM = c.CRM,
                Proprio = c.IsProprio ? "Sim": "Não" ,
                Sexo = c.Sexo.Equals("M") ? "Masculino" : "Feminino"
            }).ToList();

            return View(medicos);
        }

        [HttpPost]
        public IActionResult Index(MedicosVM model)
        {

            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    _context.Add(model.Insert(_user.Id));
                    _context.SaveChanges();
                    _notify.Success("Médico cadastrado com sucesso.");
                }
                else
                {
                    _context.Update(model.Update(_context, model.Id));
                    _context.SaveChanges();
                    _notify.Success("Médico editado com sucesso.");
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
                return View(new MedicosVM());
            else
                return View(new MedicosVM(_context, id));
        }

        public IActionResult Delete(int id)
        {
            var material = _context.Pacientes.FirstOrDefault(c => c.Id == id);
            material.IsAtivo = false;
            _context.Update(material);
            _context.SaveChanges();
            _notify.Success("Médicos apagado com sucesso.");

            return RedirectToAction(nameof(Index));
        }

    }
}