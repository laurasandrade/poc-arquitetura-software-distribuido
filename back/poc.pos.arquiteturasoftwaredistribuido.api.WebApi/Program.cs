using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using poc.pos.arquiteturasoftwaredistribuido.api.Infra.Entity;
using System;
using Thinktecture;
using Thinktecture.Extensions.Configuration;

namespace poc.pos.arquiteturasoftwaredistribuido.api.WebApi
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "poc.pos.arquiteturasoftwaredistribuido.api";
            var host = CreateHostBuilder(args).Build();

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    var loggingConfig = new LoggingConfiguration();
                    webBuilder.ConfigureServices(config => config.AddSingleton<ILoggingConfiguration>(loggingConfig));
                    webBuilder.ConfigureAppConfiguration(config =>
                    {
                        config.AddLoggingConfiguration(loggingConfig, "Logging");
                    });
                });
    }
}
