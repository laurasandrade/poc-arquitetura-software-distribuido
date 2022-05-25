using poc.pos.arquiteturasoftwaredistribuido.api.Domain.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace poc.pos.arquiteturasoftwaredistribuido.api.Infra.Entity
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public virtual DbSet<EspecialidadeEntity> EspecialidadeEntity { get; set; } = default!;
        public virtual DbSet<MedicoEntity> MedicoEntity { get; set; } = default!;
        public virtual DbSet<UsuarioEntity> UsuarioEntity { get; set; } = default!;
    }
}
