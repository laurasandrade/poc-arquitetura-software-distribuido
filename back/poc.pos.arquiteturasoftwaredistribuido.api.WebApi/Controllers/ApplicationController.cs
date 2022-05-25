using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using Thinktecture.Extensions.Configuration;

namespace poc.pos.arquiteturasoftwaredistribuido.api.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBaseApi
    {
        private readonly ILogger<ApplicationController> logger;
        private readonly ILoggingConfiguration loggingConfiguration;

        public ApplicationController(ILogger<ApplicationController> logger,
                                     ILoggingConfiguration loggingConfiguration)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.loggingConfiguration = loggingConfiguration ?? throw new ArgumentNullException(nameof(loggingConfiguration));
        }
        [HttpGet]
        public IActionResult SendMessage()
        {
            logger.LogDebug("Teste LogDebug");
            logger.LogInformation("Teste LogInformation");
            logger.LogWarning("Teste LogWarning");
            logger.LogCritical("Teste LogCritical");
            logger.LogError("Teste LogError");
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult ChangeLogLevel(LogLevel logLevel, string? category = null, string? provider = null)
        {
            logger.LogWarning($"Alterando o log level da aplicação para {logLevel}.");
            loggingConfiguration.SetLevel(logLevel, category, provider);
            return Ok(new { logLevel = logLevel.ToString() });
        }
    }
}
