using poc.pos.arquiteturasoftwaredistribuido.api.Domain.Model;
using poc.pos.arquiteturasoftwaredistribuido.api.Domain.Model.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace poc.pos.arquiteturasoftwaredistribuido.api.Domain.Contract.Service
{
    public interface IEspecialidadeService
    {
        Task<BaseResponse<EspecialidadeEntity>> CreateNewAsync(EspecialidadeEntity especialidade);
        Task<BaseResponse<EspecialidadeEntity>> DeleteAsync(int idEspecialidade);
        Task<BaseResponse<EspecialidadeEntity>> GetByIdAsync(int idEspecialidade);
        Task<BaseResponse<List<EspecialidadeEntity>>> ListAsync();
        Task<BaseResponse<EspecialidadeEntity>> UpdateAsync(EspecialidadeEntity request);
    }
}
