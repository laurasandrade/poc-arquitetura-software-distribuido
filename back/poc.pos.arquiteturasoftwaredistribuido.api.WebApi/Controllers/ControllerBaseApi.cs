using Microsoft.AspNetCore.Mvc;
using poc.pos.arquiteturasoftwaredistribuido.api.Domain.Model;
using System;
using System.Threading.Tasks;

namespace poc.pos.arquiteturasoftwaredistribuido.api.WebApi.Controllers
{
    public class ControllerBaseApi : ControllerBase
    {
        public IActionResult ExecuteMethod<TResult>(Func<BaseResponse<TResult>> function) => Result(function.Invoke());

        public async Task<IActionResult> ExecuteMethodAsync<TResult>(Func<Task<BaseResponse<TResult>>> function) => Result(await function.Invoke());

        public IActionResult Result<T>(BaseResponse<T> response)
        {
            if (response.Success)
                return Ok(response);
            else
                return BadRequest(response);
        }
    }
}
