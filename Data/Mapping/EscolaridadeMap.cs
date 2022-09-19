using Confitec.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Confitec.Data.Mapping
{
    public class EscolaridadeMap : IEntityTypeConfiguration<Escolaridade>
    {
        public void Configure(EntityTypeBuilder<Escolaridade> builder)
        {
            builder.HasKey(x => x.Id);


            builder
                .HasMany(u => u.Usuarios)
                .WithOne(e => e.Escolaridade);
        }
    }
}
