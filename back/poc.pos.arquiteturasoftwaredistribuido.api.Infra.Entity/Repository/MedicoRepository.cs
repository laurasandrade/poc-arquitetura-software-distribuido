using Microsoft.Extensions.Logging;
using poc.pos.arquiteturasoftwaredistribuido.api.Domain.Contract.Infrastructure.Repository;
using poc.pos.arquiteturasoftwaredistribuido.api.Domain.Model.Entity;

namespace poc.pos.arquiteturasoftwaredistribuido.api.Infra.Entity.Repository
{
    public class MedicoRepository : BaseRepository<ApplicationDbContext, MedicoEntity>, IMedicoRepository
    {
        public MedicoRepository(ApplicationDbContext context,
                              ILogger<MedicoRepository> logger) : base(context, logger)
        { }
    }
}
