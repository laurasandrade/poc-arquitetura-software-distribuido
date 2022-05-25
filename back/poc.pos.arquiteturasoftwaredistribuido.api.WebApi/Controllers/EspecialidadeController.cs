using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using poc.pos.arquiteturasoftwaredistribuido.api.Domain.Contract.Service;
using poc.pos.arquiteturasoftwaredistribuido.api.Domain.Model;
using poc.pos.arquiteturasoftwaredistribuido.api.Domain.Model.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;

namespace poc.pos.arquiteturasoftwaredistribuido.api.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class EspecialidadeController : ControllerBaseApi
    {
        private readonly IEspecialidadeService especialidadeService;
        private readonly ILogger<EspecialidadeController> logger;

        public EspecialidadeController(IEspecialidadeService especialidadeService, ILogger<EspecialidadeController> logger)
        {
            this.especialidadeService = especialidadeService;
            this.logger = logger;
        }

        [HttpGet("lista")]
        [ProducesResponseType(typeof(BaseResponse<List<EspecialidadeEntity>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ListAsync()
        {
            logger.LogInformation($"Obtendo especialidades");
            return await ExecuteMethodAsync(() => especialidadeService.ListAsync());
        }

        [HttpGet]
        [ProducesResponseType(typeof(BaseResponse<EspecialidadeEntity>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetByIdAsync([Required] int idEspecialidade)
        {
            logger.LogInformation($"Obtendo especialidade com o ID {idEspecialidade}");
            return await ExecuteMethodAsync(() => especialidadeService.GetByIdAsync(idEspecialidade));
        }

        [HttpPost]
        [ProducesResponseType(typeof(BaseResponse<EspecialidadeEntity>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateNewAsync([Required, FromBody] EspecialidadeEntity especialidade)
        {
            logger.LogInformation($"Criando o especialidade {especialidade.Nome}");
            return await ExecuteMethodAsync(() => especialidadeService.CreateNewAsync(especialidade));
        }

        [HttpPut]
        [ProducesResponseType(typeof(BaseResponse<EspecialidadeEntity>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateNameAsync([Required, FromBody] EspecialidadeEntity especialidade)
        {
            logger.LogInformation($"Atualizando o especialidade {especialidade.Nome}");
            return await ExecuteMethodAsync(() => especialidadeService.UpdateAsync(especialidade));
        }

        [HttpDelete]
        [ProducesResponseType(typeof(BaseResponse<EspecialidadeEntity>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteAsync([Required] int idEspecialidade)
        {
            logger.LogInformation($"Removendo o especialidade {idEspecialidade}");
            return await ExecuteMethodAsync(() => especialidadeService.DeleteAsync(idEspecialidade));
        }
    }
}
