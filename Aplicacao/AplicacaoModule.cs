using Aplicacao.Empresas;
using Dominio.Empresas;
using Hbsis.Wms.Infra.Repositorios;
using Infra.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Aplicacao
{
    public static class AplicacaoModule
    {

        public static IServiceCollection AddTransactionFramework(
            this IServiceCollection services, 
            IConfiguration configuration
        )
        {
            // Service
            services.AddScoped<IEmpresaService, EmpresaService>();

            // Repository
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();

            // Mappers
            services.AddScoped<IEmpresaMapper, EmpresaMapper>();

            // Connection String
            services.AddDbContext<ContextoBase>(
                options => 
                    options.UseSqlServer(
                        configuration.GetConnectionString("SqlServerConnection")
                    )
            );

            return services;
        }
    }
}
