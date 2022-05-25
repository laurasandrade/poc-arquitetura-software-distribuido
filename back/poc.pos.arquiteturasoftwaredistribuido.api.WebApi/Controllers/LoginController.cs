using Microsoft.AspNetCore.Mvc;
using poc.pos.arquiteturasoftwaredistribuido.api.Domain.Contract.Service;
using poc.pos.arquiteturasoftwaredistribuido.api.Domain.Model.Entity;
using poc.pos.arquiteturasoftwaredistribuido.api.Domain.Model.Request;
using System.Threading.Tasks;

namespace poc.pos.arquiteturasoftwaredistribuido.api.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LoginController : ControllerBaseApi
    {
        private readonly ILoginService loginService;

        public LoginController(ILoginService loginService)
        {
            this.loginService = loginService;
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginRequest request)
        {
            var retorno = await loginService.LoginAsync(request);

            if (retorno.authenticated)
            {
                return Ok(retorno);
            }
            else
            {
                return BadRequest(retorno);
            }
        }

        [HttpPost("cadastro")]
        public async Task<IActionResult> CadastrarAsync(UsuarioEntity request)
        {
            var retorno = await loginService.CadastrarAsync(request);

            if (retorno.authenticated)
            {
                return Ok(retorno);
            }
            else
            {
                return BadRequest(retorno);
            }
        }
    }
}
