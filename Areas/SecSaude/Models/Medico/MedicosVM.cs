using SecSaudeAH.Models.BDSECSAUDE.Context;
using SecSaudeAH.Models.BDSECSAUDE.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecSaudeAH.Areas.SecSaude.Models.MedicoVM
{
    public class MedicosVM
    {
        public MedicosVM()
        {
        }

        public MedicosVM(DBSaudeAHContext _context, int id)
        {
            var unidade = _context.Medicos.First(c => c.Id == id);
            this.Nome = unidade.Nome;
            this.CRM = unidade.CRM;
            this.Sexo = unidade.Sexo;
            this.IsProprio = unidade.IsProprio;
        }

        public int Id { get; set; }

        [Required(ErrorMessage = Global.Required)]
        public string Nome { get; set; }

        [Required(ErrorMessage = Global.Required)]
        public string Sexo { get; set; }

        public string CRM { get; set; }

        [Required(ErrorMessage = Global.Required)]
        public bool IsProprio { get; set; }

        public string Proprio { get; set; }

        public Medico Insert(int id) => new Medico() { ProfissionalId = id, Nome = Nome, Sexo = Sexo, CRM = CRM, IsProprio = IsProprio };

        public Medico Update(DBSaudeAHContext _context, int id)
        {
            var medico = _context.Medicos.First(c => c.Id == id);
            medico.Nome = this.Nome;
            medico.CRM = this.CRM;
            medico.Sexo = this.Sexo;
            medico.IsProprio = this.IsProprio;
            return medico;
        }

    }
}
