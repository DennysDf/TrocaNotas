using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecSaudeAH.Areas.SecSaude.Models.Pacientes;
using SecSaudeAH.Models.BDSECSAUDE.Context;
using SecSaudeAH.Services.Interfaces;

namespace SecSaudeAH.Areas.SecSaude.Controllers
{
    [Authorize]
    [Area("SecSaude")]
    public class PacientesController : Controller
    {
        private readonly DBSaudeAHContext _context;
        private readonly IUser _user;
        private readonly INotificacao _notify;


        public PacientesController(DBSaudeAHContext context, IUser user, INotificacao notidy)
        {
            _context = context;
            _user = user;
            _notify = notidy;
        }

        public IActionResult Index()
        {
            var pacientes = _context.Pacientes.Where(c => c.IsAtivo).Select(c => new PacientesVM
            {
                Id = c.Id,
                Nome = c.Nome,
                Endereco = c.Endereco,
                CNS = c.CNS,
                CPF = c.CPF,
                IsAtivo = c.IsAtivo,
                DataNasc = c.DataNasc,
                NomeMae = c.NomeMae,
                Telefone = c.Telefone
            }).ToList();

            return View(pacientes);
        }

        [HttpPost]
        public IActionResult Index(PacientesVM model)
        {

            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    _context.Add(model.Insert(_user.Id));
                    _context.SaveChanges();
                    _notify.Success("Paciente cadastrado com sucesso.");
                }
                else
                {
                    _context.Update(model.Update(_context, model.Id));
                    _context.SaveChanges();
                    _notify.Success("Paciente editado com sucesso.");
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
                return View(new PacientesVM());
            else
                return View(new PacientesVM(_context, id));
        }

        public IActionResult Delete(int id)
        {
            var material = _context.Pacientes.FirstOrDefault(c => c.Id == id);
            material.IsAtivo = false;
            _context.Update(material);
            _context.SaveChanges();
            _notify.Success("Paciente apagado com sucesso.");

            return RedirectToAction(nameof(Index));
        }

    }
}