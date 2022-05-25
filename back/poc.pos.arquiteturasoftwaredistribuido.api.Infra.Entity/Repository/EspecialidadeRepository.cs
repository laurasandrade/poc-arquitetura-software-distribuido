using Microsoft.Extensions.Logging;
using poc.pos.arquiteturasoftwaredistribuido.api.Domain.Contract.Infrastructure.Repository;
using poc.pos.arquiteturasoftwaredistribuido.api.Domain.Model.Entity;

namespace poc.pos.arquiteturasoftwaredistribuido.api.Infra.Entity.Repository
{
    public class EspecialidadeRepository : BaseRepository<ApplicationDbContext, EspecialidadeEntity>, IEspecialidadeRepository
    {
        public EspecialidadeRepository(ApplicationDbContext context,
                              ILogger<EspecialidadeRepository> logger) : base(context, logger)
        { }
    }
}
