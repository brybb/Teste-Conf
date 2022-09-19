using System;
using Confitec.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Confitec.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> context) : base(context)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new EscolaridadeMap());
            modelBuilder.ApplyConfiguration(new HistoricoEscolarMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
