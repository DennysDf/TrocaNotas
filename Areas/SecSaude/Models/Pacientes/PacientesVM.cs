using SecSaudeAH.Models.BDSECSAUDE.Context;
using SecSaudeAH.Models.BDSECSAUDE.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecSaudeAH.Areas.SecSaude.Models.Pacientes
{
    public class PacientesVM
    {
        public PacientesVM()
        {

        }

        public PacientesVM(DBSaudeAHContext _context, int pacienteId)
        {
            var paciente = _context.Pacientes.First(c => c.Id == pacienteId);
            this.Nome = paciente.Nome;
            this.Endereco = paciente.Endereco;
            this.CPF = paciente.CPF;
            this.CNS = paciente.CNS;
            this.NomeMae = paciente.NomeMae;
            this.Telefone = paciente.Telefone;
            this.DataNasc = paciente.DataNasc;
        }

        public int Id { get; set; }
        [Required(ErrorMessage = Global.Required)]
        public string Nome { get; set; }
        [Required(ErrorMessage = Global.Required)]
        [MinLength(18, ErrorMessage = "CNS inválido.")]
        public string CNS { get; set; }
        [Required(ErrorMessage = Global.Required)]
        [MinLength(14,ErrorMessage = "CPF inválido.")]
        public string CPF { get; set; }
        [Required(ErrorMessage = Global.Required)]
        public string NomeMae { get; set; }
        [Required(ErrorMessage = Global.Required)]
        public string DataNasc { get; set; }
        [Required(ErrorMessage = Global.Required)]
        public string Endereco { get; set; }

        [Required(ErrorMessage = Global.Required)]
        [MinLength(16, ErrorMessage = Global.ErroCelular)]
        public string Telefone { get; set; }
        public int ProfissionalId { get; set; }

        public bool IsAtivo { get; set; }

        public Paciente Insert(int id) => new Paciente() { ProfissionalId = id, Nome = Nome, CNS = CNS, CPF = CPF, NomeMae = NomeMae, Endereco = Endereco, DataNasc = DataNasc, Telefone = Telefone };

        public Paciente Update(DBSaudeAHContext _context, int id)
        {
            var paciente = _context.Pacientes.First(c => c.Id == id);
            paciente.Nome = this.Nome;
            paciente.Endereco = this.Endereco;
            paciente.NomeMae = this.NomeMae;
            paciente.DataNasc = this.DataNasc;
            paciente.CPF = this.CPF;
            paciente.CNS = this.CNS;            
            paciente.Telefone = this.Telefone;
            return paciente;
        }
    }
}
