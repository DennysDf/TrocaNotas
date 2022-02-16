using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace SecSaudeAH.Models.BDSECSAUDE.Entidades
{
    public class Secretaria
    {

        public Secretaria()
        {
            Profissionais = new HashSet<Profissional>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public bool IsAtivo { get; set; }
        public DateTime DataCad { get; set; }

        public ICollection<Profissional> Profissionais { get; set; }
    }
}
