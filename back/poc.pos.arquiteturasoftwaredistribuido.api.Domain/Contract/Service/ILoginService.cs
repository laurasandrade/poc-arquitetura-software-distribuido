using poc.pos.arquiteturasoftwaredistribuido.api.Domain.Model.Entity;
using poc.pos.arquiteturasoftwaredistribuido.api.Domain.Model.Request;
using poc.pos.arquiteturasoftwaredistribuido.api.Domain.Model.Response;
using System.Threading.Tasks;

namespace poc.pos.arquiteturasoftwaredistribuido.api.Domain.Contract.Service
{
    public interface ILoginService
    {
        Task<LoginResponse> LoginAsync(LoginRequest request);
        Task<LoginResponse> CadastrarAsync(UsuarioEntity usuarioEntity);
    }
}
