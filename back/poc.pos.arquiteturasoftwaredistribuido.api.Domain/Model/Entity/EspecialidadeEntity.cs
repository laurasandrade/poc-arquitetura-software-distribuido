using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace poc.pos.arquiteturasoftwaredistribuido.api.Domain.Model.Entity
{
    [Table("especialidade")]
    public class EspecialidadeEntity
    {
        [Key, Required]
        public int IdEspecialidade { get; set; }
        public string Nome { get; set; } = default!;
    }
}
