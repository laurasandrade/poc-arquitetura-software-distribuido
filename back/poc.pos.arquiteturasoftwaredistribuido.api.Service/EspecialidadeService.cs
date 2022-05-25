using Microsoft.Extensions.Logging;
using poc.pos.arquiteturasoftwaredistribuido.api.Domain.Contract.Infrastructure.Repository;
using poc.pos.arquiteturasoftwaredistribuido.api.Domain.Contract.Service;
using poc.pos.arquiteturasoftwaredistribuido.api.Domain.Model;
using poc.pos.arquiteturasoftwaredistribuido.api.Domain.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace poc.pos.arquiteturasoftwaredistribuido.api.Service
{
    public class EspecialidadeService : IEspecialidadeService
    {
        private readonly IEspecialidadeRepository especialidadeRepository;
        private readonly ILogger<EspecialidadeService> logger;

        public EspecialidadeService(IEspecialidadeRepository especialidadeRepository,
                           ILogger<EspecialidadeService> logger)
        {
            this.logger = logger;
            this.especialidadeRepository = especialidadeRepository;
        }

        public async Task<BaseResponse<EspecialidadeEntity>> CreateNewAsync(EspecialidadeEntity especialidade)
        {
            logger.LogWarning($"Criando uma nova especialidade...");
            return await especialidadeRepository.InsertAsync(especialidade);
        }

        public async Task<BaseResponse<EspecialidadeEntity>> DeleteAsync(int idEspecialidade)
        {
            logger.LogInformation($"Removendo a especialidade {idEspecialidade}...");
            return await especialidadeRepository.RemoveAsync(idEspecialidade);
        }

        public async Task<BaseResponse<EspecialidadeEntity>> GetByIdAsync(int idEspecialidade)
        {
            logger.LogInformation($"Obtendo especialidade de id: {idEspecialidade}");
            return await especialidadeRepository.GetByIdAsync(idEspecialidade);
        }

        public async Task<BaseResponse<List<EspecialidadeEntity>>> ListAsync()
        {
            logger.LogInformation($"Obtendo especialidades");
            return await especialidadeRepository.FilterAsync();
        }

        public async Task<BaseResponse<EspecialidadeEntity>> UpdateAsync(EspecialidadeEntity request)
        {
            logger.LogInformation($"Atualizando especialidade {request.IdEspecialidade}...");
            var especialidade = await especialidadeRepository.GetByIdAsync(request.IdEspecialidade);
            if (!especialidade.Success)
            {
                return especialidade;
            }
            especialidade.Data.Nome = request.Nome;
            return await especialidadeRepository.UpdateAsync(especialidade.Data);
        }
    }
}
