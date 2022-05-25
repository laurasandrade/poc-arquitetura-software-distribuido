using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using poc.pos.arquiteturasoftwaredistribuido.api.Domain.Contract.Infrastructure.Repository;
using poc.pos.arquiteturasoftwaredistribuido.api.Domain.Contract.Service;
using poc.pos.arquiteturasoftwaredistribuido.api.Infra.Entity;
using poc.pos.arquiteturasoftwaredistribuido.api.Infra.Entity.Repository;
using poc.pos.arquiteturasoftwaredistribuido.api.Service;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;

namespace poc.pos.arquiteturasoftwaredistribuido.api.WebApi.Infrastructure.Container
{
    public static class WebApiStartup
    {
        private const string apiCulture = "WebapiCulture";

        public static RequestLocalizationOptions Location(IConfiguration configuration) => new RequestLocalizationOptions
        {
            SupportedCultures = new List<CultureInfo> { new CultureInfo(configuration[apiCulture]) },
            SupportedUICultures = new List<CultureInfo> { new CultureInfo(configuration[apiCulture]) },
            DefaultRequestCulture = new RequestCulture(configuration[apiCulture])
        };

        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseMySQL(configuration.GetConnectionString("Default")),
                                                 ServiceLifetime.Scoped);
            RegisterServices(services);
            RegisterRepositories(services);
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IMedicoService, MedicoService>();
            services.AddScoped<IEspecialidadeService, EspecialidadeService>();
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IMedicoRepository, MedicoRepository>();
            services.AddScoped<IEspecialidadeRepository, EspecialidadeRepository>();
        }
    }
}
