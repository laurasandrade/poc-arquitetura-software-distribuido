using Microsoft.Extensions.Logging;
using poc.pos.arquiteturasoftwaredistribuido.api.Domain.Contract.Infrastructure.Repository;
using poc.pos.arquiteturasoftwaredistribuido.api.Domain.Contract.Service;
using poc.pos.arquiteturasoftwaredistribuido.api.Domain.Model;
using poc.pos.arquiteturasoftwaredistribuido.api.Domain.Model.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace poc.pos.arquiteturasoftwaredistribuido.api.Service
{
    public class MedicoService : IMedicoService
    {
        private readonly IMedicoRepository medicoRepository;
        private readonly ILogger<MedicoService> logger;

        public MedicoService(IMedicoRepository medicoRepository,
                           ILogger<MedicoService> logger)
        {
            this.logger = logger;
            this.medicoRepository = medicoRepository;
        }

        public async Task<BaseResponse<MedicoEntity>> CreateNewAsync(MedicoEntity medico)
        {
            logger.LogWarning($"Criando uma nova medico...");
            return await medicoRepository.InsertAsync(medico);
        }

        public async Task<BaseResponse<MedicoEntity>> DeleteAsync(int idMedico)
        {
            logger.LogInformation($"Removendo a medico {idMedico}...");
            return await medicoRepository.RemoveAsync(idMedico);
        }

        public async Task<BaseResponse<MedicoEntity>> GetByIdAsync(int idMedico)
        {
            logger.LogInformation($"Obtendo medico de id: {idMedico}");
            return await medicoRepository.GetByIdAsync(idMedico);
        }

        public async Task<BaseResponse<List<MedicoEntity>>> ListAsync()
        {
            logger.LogInformation($"Obtendo medicos");
            return await medicoRepository.FilterAsync();
        }

        public async Task<BaseResponse<MedicoEntity>> UpdateAsync(MedicoEntity request)
        {
            logger.LogInformation($"Atualizando medico {request.IdMedico}...");
            var medico = await medicoRepository.GetByIdAsync(request.IdMedico);
            if(!medico.Success)
            {
                return medico;
            }
            medico.Data.Nome = request.Nome;
            medico.Data.Email = request.Email;
            medico.Data.Telefone = request.Telefone;
            medico.Data.IdEspecialidade = request.IdEspecialidade;
            return await medicoRepository.UpdateAsync(medico.Data);
        }
    }
}
