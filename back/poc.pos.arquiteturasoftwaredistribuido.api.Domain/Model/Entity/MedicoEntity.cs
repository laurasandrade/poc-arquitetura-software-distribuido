using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace poc.pos.arquiteturasoftwaredistribuido.api.Domain.Model.Entity
{
    [Table("medico")]
    public class MedicoEntity
    {
        [Key, Required]
        public int IdMedico { get; set; }
        public string Nome { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Telefone { get; set; } = default!;

        [ForeignKey(nameof(EspecialidadeEntity))]
        public int IdEspecialidade { get; set; }

        public EspecialidadeEntity? EspecialidadeEntity { get; set; }
    }
}
