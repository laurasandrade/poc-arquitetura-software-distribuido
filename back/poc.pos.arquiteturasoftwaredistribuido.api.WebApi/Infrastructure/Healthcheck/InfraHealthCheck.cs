using poc.pos.arquiteturasoftwaredistribuido.api.Infra.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace poc.pos.arquiteturasoftwaredistribuido.api.WebApi.Infrastructure.Healthcheck
{
    public class InfraHealthCheck : IHealthCheck
    {
        private readonly ApplicationDbContext kulaDbContext;
        public InfraHealthCheck(ApplicationDbContext kulaDbContext) => this.kulaDbContext = kulaDbContext;

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                await kulaDbContext.Database.OpenConnectionAsync(default);
                await kulaDbContext.Database.CloseConnectionAsync();
            }
            catch (Exception ex)
            {
                return new HealthCheckResult(status: context.Registration.FailureStatus, exception: ex);
            }
            return HealthCheckResult.Healthy();
        }
    }
}
