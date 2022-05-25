using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Collections.Generic;

namespace poc.pos.arquiteturasoftwaredistribuido.api.WebApi.Infrastructure.Configuration
{
    public static class SwaggerConfig
    {
        private const string authorization = "Authorization";
        private const string oauth2 = "oauth2";
        private const string tokenType = "Bearer";
        private const string tokenDescription = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"";

        public static void SwaggerService(this IServiceCollection services)
            => services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "poc.pos.arquiteturasoftwaredistribuido.api WebApi", Version = "v1" });
                c.AddSecurityDefinition(tokenType, new OpenApiSecurityScheme
                {
                    Description = tokenDescription,
                    Name = authorization,
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = tokenType
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = tokenType
                            },
                            Scheme = oauth2,
                            Name = tokenType,
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
            });

        public static void SwaggerConfigure(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "poc.pos.arquiteturasoftwaredistribuido.api WebApi");
                c.RoutePrefix = string.Empty;
                c.DocExpansion(DocExpansion.None);
            });
        }
    }
}
