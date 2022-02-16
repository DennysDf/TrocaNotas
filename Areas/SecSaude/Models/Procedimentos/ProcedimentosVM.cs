using SecSaudeAH.Models.BDSECSAUDE.Context;
using SecSaudeAH.Models.BDSECSAUDE.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecSaudeAH.Areas.SecSaude.Models.Procedimentos
{
    public class ProcedimentosVM
    {

        public ProcedimentosVM()
        {

        }

        public ProcedimentosVM(DBSaudeAHContext _context, int id)
        {
            var procedimento = _context.Procedimentos.First(c => c.Id == id);
            this.Nome = procedimento.Nome;
            this.Valor = procedimento.ValorMed;
            this.Tipo = procedimento.Tipo;
        }

        public int Id { get; set; }
        [Required(ErrorMessage = Global.Required)]
        public string Nome { get; set; }
        [Required(ErrorMessage = Global.Required)]
        public int Tipo { get; set; }
        public string TipoText { get; set; }

        public string Valor { get; set; }
        

        public Procedimento Insert(int id) => new Procedimento() { ProfissionalId = id, Nome = Nome, ValorMed = Valor, Tipo = Tipo };

        public Procedimento Update(DBSaudeAHContext _context, int id)
        {
            var procedimento = _context.Procedimentos.First(c => c.Id == id);
            procedimento.Nome = this.Nome;
            procedimento.ValorMed = this.Valor;
            procedimento.Tipo = this.Tipo;
            return procedimento;
        }
    }
}
