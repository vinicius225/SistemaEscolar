using Microsoft.Extensions.DependencyInjection;
using SistemaEscolar.Aplication.Interfaces;
using SistemaEscolar.Aplication.Services;
using SistemaEscolar.Domain.Interfaces;
using SistemaEscolar.Infra.Data;
using SistemaEscolar.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Infra.IoC
{
    public static class InjectorDependence
    {
        public static void ConnectionDatabase(this IServiceCollection service)
        {
            service.AddScoped<IConectionFactory, ConectionFactory>();
        }

        public static void RepositoryInjector(this IServiceCollection service) 
        {
            service.AddScoped<IUsuarioRepository, UsuarioRepository>();
        }
        public static void ServiceInjector (this IServiceCollection services)
        {
            services.AddScoped<IUsuarioService, UsuarioService>();
        }
    }
}
