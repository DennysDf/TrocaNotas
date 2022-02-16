using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SecSaudeAH.Models.BDSECSAUDE.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecSaudeAH.Models.BDSECSAUDE.Mappers
{
    public class PacienteMapper : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.Property(c => c.DataCad).HasDefaultValueSql("(getdate())");
            builder.Property(c => c.IsAtivo).HasDefaultValue(true);

            builder.HasOne(c => c.Profissional)
                .WithMany(c => c.Pacientes)
                .HasForeignKey(c => c.ProfissionalId)
                .OnDelete(DeleteBehavior.ClientSetNull);

        }
    }
}
