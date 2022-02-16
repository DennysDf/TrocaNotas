using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecSaudeAH.Models.BDSECSAUDE.Entidades
{
    public class Unidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public int Tipo { get; set; }
        public bool IsAtivo { get; set; }
        public DateTime DataCad { get; set; }
        public int ProfissionalId { get; set; }
        public Profissional Profissional { get; set; }
    }
}
