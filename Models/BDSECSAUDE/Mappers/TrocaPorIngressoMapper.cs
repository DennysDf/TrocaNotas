using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SecSaudeAH.Models.BDSECSAUDE.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecSaudeAH.Models.BDSECSAUDE.Mappers
{
    public class TrocaPorIngressoMapper : IEntityTypeConfiguration<TrocarPorIngresso>
    {
        public void Configure(EntityTypeBuilder<TrocarPorIngresso> builder)
        {
            builder.Property(c => c.DataCad).HasDefaultValueSql("(getdate())");
            builder.Property(c => c.IsAtivo).HasDefaultValue(true);

            builder.HasOne(c => c.Profissional)
                .WithMany(c => c.Trocas)
                .HasForeignKey(c => c.ProfissionalId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(c => c.Cidadao)
                .WithMany(c => c.Trocas)
                .HasForeignKey(c => c.CidadaoId)
                .OnDelete(DeleteBehavior.ClientSetNull);

        }
    }
}
