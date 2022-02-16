using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecSaudeAH.Models.BDSECSAUDE.Entidades
{
    public class TrocarPorIngresso
    {
        public int Id { get; set; }
        public int Valor { get; set; }
        public int CidadaoId { get; set; }
        public Paciente Cidadao { get; set; }
        public int ProfissionalId { get; set; }
        public Profissional Profissional { get; set; }
        public DateTime DataCad { get; set; }
        public bool IsAtivo { get; set; }
        public string Data { get; set; }
    }
}
