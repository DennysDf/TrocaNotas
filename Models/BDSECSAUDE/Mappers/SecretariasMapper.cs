using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SecSaudeAH.Models.BDSECSAUDE.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecSaudeAH.Models.BDSECSAUDE.Mappers
{
    public class SecretariasMapper : IEntityTypeConfiguration<Secretaria>
    {
        public void Configure(EntityTypeBuilder<Secretaria> builder) 
        {
            builder.Property(c => c.DataCad).HasDefaultValueSql("(getdate())");
            builder.Property(c => c.IsAtivo).HasDefaultValue(true);
        }
    }
}
