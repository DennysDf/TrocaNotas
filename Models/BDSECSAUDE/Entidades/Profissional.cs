using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecSaudeAH.Models.BDSECSAUDE.Entidades
{
    public class Profissional
    {
        public Profissional()
        {
            Pacientes = new HashSet<Paciente>();
            Hospitais = new HashSet<Hospital>();
            Procedimentos = new HashSet<Procedimento>();
            Unidades = new HashSet<Unidade>();
            Medicos = new HashSet<Medico>();
            Notas = new HashSet<NotasFiscais>();
            Trocas = new HashSet<TrocarPorIngresso>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Extensao { get; set; }
        public int SecretariaId { get; set; }
        public Secretaria Secretaria { get; set; }
        public bool IsAtivo { get; set; }
        public DateTime? LastLogin { get; set; }
        public DateTime DataCad { get; set; }
        public int Tipo { get; set; }
        public string Funcao { get; set; }

        public ICollection<Hospital> Hospitais { get; set; }
        public ICollection<Medico> Medicos { get; set; }
        public ICollection<Paciente> Pacientes { get; set; }
        public ICollection<Procedimento> Procedimentos { get; set; }
        public ICollection<Unidade> Unidades { get; set; }
        public ICollection<NotasFiscais> Notas { get; set; }
        public ICollection<TrocarPorIngresso> Trocas { get; set; }

    }
}
