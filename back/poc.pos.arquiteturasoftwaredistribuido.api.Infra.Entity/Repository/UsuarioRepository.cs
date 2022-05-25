using Microsoft.Extensions.Logging;
using poc.pos.arquiteturasoftwaredistribuido.api.Domain.Contract.Infrastructure.Repository;
using poc.pos.arquiteturasoftwaredistribuido.api.Domain.Model.Entity;

namespace poc.pos.arquiteturasoftwaredistribuido.api.Infra.Entity.Repository
{
    public class UsuarioRepository : BaseRepository<ApplicationDbContext, UsuarioEntity>, IUsuarioRepository
    {
        public UsuarioRepository(ApplicationDbContext context,
                              ILogger<UsuarioRepository> logger) : base(context, logger)
        { }
    }
}
