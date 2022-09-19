using Confitec.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Confitec.Data.Mapping
{
    public class HistoricoEscolarMap : IEntityTypeConfiguration<HistoricoEscolar>
    {
        public void Configure(EntityTypeBuilder<HistoricoEscolar> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasOne(h => h.Usuario)
                .WithMany(u => u.HistoricoEscolar)
                .HasForeignKey(p => p.UsuarioId)
                     .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
