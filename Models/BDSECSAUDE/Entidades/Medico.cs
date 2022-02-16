using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecSaudeAH.Models.BDSECSAUDE.Entidades
{
    public class Medico
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool IsProprio { get; set; }
        public string CRM { get; set; }
        public string Sexo { get; set; }
        public bool IsAtivo { get; set; }
        public DateTime DataCad { get; set; }
        public int ProfissionalId { get; set; }
        public Profissional Profissional { get; set; }
    }
}
