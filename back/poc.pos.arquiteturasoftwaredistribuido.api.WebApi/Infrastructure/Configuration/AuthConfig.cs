using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Net.Http;

namespace poc.pos.arquiteturasoftwaredistribuido.api.WebApi.Infrastructure.Configuration
{
    public static class AuthConfig
    {
        public static void AddAuth(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer("KulaSSO", x =>
            {
                x.Authority = configuration["SSO:Authority"];
                x.Audience = configuration["SSO:Audience"];
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateLifetime = true,
                };
                x.BackchannelHttpHandler = new HttpClientHandler { ServerCertificateCustomValidationCallback = delegate { return true; } };
            });

            services.AddAuthorization(x =>
            {
                var defaultAuthorizationPolicyBuilder = new AuthorizationPolicyBuilder("KulaSSO");
                defaultAuthorizationPolicyBuilder = defaultAuthorizationPolicyBuilder.RequireAuthenticatedUser();
                x.DefaultPolicy = defaultAuthorizationPolicyBuilder.Build();
            });
        }
    }
}
