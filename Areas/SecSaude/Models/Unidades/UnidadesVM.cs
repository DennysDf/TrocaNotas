using SecSaudeAH.Models.BDSECSAUDE.Context;
using SecSaudeAH.Models.BDSECSAUDE.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecSaudeAH.Areas.SecSaude.Models.Unidades
{
    public class UnidadesVM
    {
        public UnidadesVM()
        {

        }

        public UnidadesVM(DBSaudeAHContext _context, int id)
        {
            var unidade = _context.Unidades.First(c => c.Id == id);
            this.Nome = unidade.Nome;
            this.Endereco = unidade.Endereco;
            this.Telefone = unidade.Telefone;
        }

        [Required(ErrorMessage = Global.Required)]
        public int Id { get; set; }
        [Required(ErrorMessage = Global.Required)]
        public string Nome { get; set; }
        [Required(ErrorMessage = Global.Required)]
        public string Endereco { get; set; }
        [Required(ErrorMessage = Global.Required)]
        public int Tipo { get; set; }
        [MinLength(16, ErrorMessage = Global.ErroCelular)]
        public string Telefone { get; set; }

        //TIPO 1 = HOSPITAL, CLINICAS
        public Unidade Insert(int id, int tipo) => new Unidade() { ProfissionalId = id, Nome = Nome, Endereco = Endereco, Telefone = Telefone, Tipo = tipo };

        public Unidade Update(DBSaudeAHContext _context, int id)
        {
            var unidade = _context.Unidades.First(c => c.Id == id);
            unidade.Nome = this.Nome;
            unidade.Endereco = this.Endereco;
            unidade.Telefone = this.Telefone;
            return unidade;
        }

    }
}
