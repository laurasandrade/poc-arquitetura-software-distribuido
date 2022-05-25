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
    public class MedicoController : ControllerBaseApi
    {
        private readonly IMedicoService medicoService;
        private readonly ILogger<MedicoController> logger;

        public MedicoController(IMedicoService medicoService, ILogger<MedicoController> logger)
        {
            this.medicoService = medicoService;
            this.logger = logger;
        }

        [HttpGet("lista")]
        [ProducesResponseType(typeof(BaseResponse<List<MedicoEntity>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ListAsync()
        {
            logger.LogInformation($"Obtendo medicos");
            return await ExecuteMethodAsync(() => medicoService.ListAsync());
        }

        [HttpGet]
        [ProducesResponseType(typeof(BaseResponse<MedicoEntity>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetByIdAsync([Required] int idMedico)
        {
            logger.LogInformation($"Obtendo medico com o ID {idMedico}");
            return await ExecuteMethodAsync(() => medicoService.GetByIdAsync(idMedico));
        }

        [HttpPost]
        [ProducesResponseType(typeof(BaseResponse<MedicoEntity>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateNewAsync([Required, FromBody] MedicoEntity medico)
        {
            logger.LogInformation($"Criando o medico {medico.Nome}");
            return await ExecuteMethodAsync(() => medicoService.CreateNewAsync(medico));
        }

        [HttpPut]
        [ProducesResponseType(typeof(BaseResponse<MedicoEntity>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateNameAsync([Required, FromBody] MedicoEntity medico)
        {
            logger.LogInformation($"Atualizando o medico {medico.Nome}");
            return await ExecuteMethodAsync(() => medicoService.UpdateAsync(medico));
        }

        [HttpDelete]
        [ProducesResponseType(typeof(BaseResponse<MedicoEntity>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteAsync([Required] int idMedico)
        {
            logger.LogInformation($"Removendo o medico {idMedico}");
            return await ExecuteMethodAsync(() => medicoService.DeleteAsync(idMedico));
        }
    }
}
