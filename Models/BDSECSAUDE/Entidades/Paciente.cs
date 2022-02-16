using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecSaudeAH.Models.BDSECSAUDE.Entidades
{
    public class Paciente
    {
        public Paciente()
        {
            Notas = new HashSet<NotasFiscais>();
            Trocas = new HashSet<TrocarPorIngresso>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string CNS { get; set; }
        public string CPF { get; set; }
        public string NomeMae { get; set; }
        public string DataNasc { get; set; }
        public string Sexo { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public int ProfissionalId { get; set; }
        public Profissional Profissional { get; set; }
        public DateTime DataCad { get; set; }
        public bool IsAtivo { get; set; }
        public ICollection<NotasFiscais> Notas { get; set; }
        public ICollection<TrocarPorIngresso> Trocas { get; set; }
    }
}
