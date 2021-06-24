using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;

namespace NetCoreWebApiPlayGround.Extensions
{
    public class EnvironmentCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context,
            CancellationToken cancellationToken = new CancellationToken())
        {
            var currEnv = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var dict = new Dictionary<string, object>
            {
                { "ASPNETCORE_ENVIRONMENT", currEnv }
            };

            if (currEnv != Environments.Development
                && currEnv != Environments.Staging
                && currEnv != Environments.Production)
            {
                return Task.FromResult(HealthCheckResult.Unhealthy("Check Environment Variable",
                    null,
                    dict));
            }

            return Task.FromResult(HealthCheckResult.Healthy("Check Environment Variable",
                dict));
        }
    }
}