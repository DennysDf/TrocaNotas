using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SecSaudeAH.Models.BDSECSAUDE.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecSaudeAH.Models.BDSECSAUDE.Mappers
{
    public class ProfissionalMapper : IEntityTypeConfiguration<Profissional>
    {
        public void Configure(EntityTypeBuilder<Profissional> builder)
        {
            builder.Property(c => c.DataCad).HasDefaultValueSql("(getdate())");
            builder.Property(c => c.IsAtivo).HasDefaultValue(true);

            builder.HasOne(c => c.Secretaria)
                .WithMany(c => c.Profissionais)
                .HasForeignKey(c => c.SecretariaId)
                .OnDelete(DeleteBehavior.ClientSetNull);

        }
    }
}
