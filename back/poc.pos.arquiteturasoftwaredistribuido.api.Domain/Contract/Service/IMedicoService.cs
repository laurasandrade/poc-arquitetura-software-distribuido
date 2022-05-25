using poc.pos.arquiteturasoftwaredistribuido.api.Domain.Model;
using poc.pos.arquiteturasoftwaredistribuido.api.Domain.Model.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace poc.pos.arquiteturasoftwaredistribuido.api.Domain.Contract.Service
{
    public interface IMedicoService
    {
        Task<BaseResponse<MedicoEntity>> CreateNewAsync(MedicoEntity medico);
        Task<BaseResponse<MedicoEntity>> UpdateAsync(MedicoEntity request);
        Task<BaseResponse<MedicoEntity>> DeleteAsync(int idMedico);
        Task<BaseResponse<MedicoEntity>> GetByIdAsync(int idMedico);
        Task<BaseResponse<List<MedicoEntity>>> ListAsync();
    }
}
