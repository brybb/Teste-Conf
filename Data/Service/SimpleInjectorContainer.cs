using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Confitec.Application.Interfaces;
using Confitec.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Confitec.Data.Service
{
   public static class SimpleInjectorContainer
    {
        public static IServiceCollection ConfigureDependecies(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContextPool<Context>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"), opt => opt.MaxBatchSize(500)));

            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddScoped<IEscolaridadeRepositorio, EscolaridadeRepositorio>();
            services.AddScoped<IHistoricoEscolarRepositorio, HistoricoEscolarRepositorio>();
            

            return services;
        }
    }
}
