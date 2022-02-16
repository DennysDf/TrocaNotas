using Microsoft.EntityFrameworkCore;
using SecSaudeAH.Models.BDSECSAUDE.Entidades;
using SecSaudeAH.Models.BDSECSAUDE.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecSaudeAH.Models.BDSECSAUDE.Context
{
    public class DBSaudeAHContext : DbContext
    {
        public DBSaudeAHContext(DbContextOptions options) : base(options)
        {            
        }

        public DbSet<Hospital> Hospitais { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Procedimento> Procedimentos { get; set; }
        public DbSet<Profissional> Profissionais { get; set; }
        public DbSet<Secretaria> Secretaria { get; set; }
        public DbSet<Unidade> Unidades { get; set; }
        public DbSet<NotasFiscais> NotaFiscais { get; set; }
        public DbSet<TrocarPorIngresso> Trocas { get; set; }
        public DbSet<Eventos> Eventos { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new HospitalMapper());
            modelBuilder.ApplyConfiguration(new MedicoMapper());
            modelBuilder.ApplyConfiguration(new PacienteMapper());
            modelBuilder.ApplyConfiguration(new ProcedimentoMapper());
            modelBuilder.ApplyConfiguration(new ProfissionalMapper());            
            modelBuilder.ApplyConfiguration(new SecretariasMapper());
            modelBuilder.ApplyConfiguration(new UnidadesMapper());
            modelBuilder.ApplyConfiguration(new NotasFiscaisMapper());
            modelBuilder.ApplyConfiguration(new TrocaPorIngressoMapper());
            modelBuilder.ApplyConfiguration(new EventoMapper());

        }
    }
}
