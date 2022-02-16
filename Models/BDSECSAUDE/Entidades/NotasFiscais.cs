using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecSaudeAH.Models.BDSECSAUDE.Entidades
{
    public class NotasFiscais
    {
        public int Id { get; set; }
        public string CNPJ { get; set; }
        public string Numero { get; set; }
        public decimal Valor { get; set; }
        public string NomeArquivo { get; set; }
        public int ProfissionalId { get; set; }
        public Profissional Profissional { get; set; }
        public int IdCidadao { get; set; }
        public Paciente Paciente { get; set; }
        public DateTime DataCad { get; set; }
        public bool IsAtivo { get; set; }
    }
}
