using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace poc.pos.arquiteturasoftwaredistribuido.api.Domain.Model.Entity
{
    [Table("usuario")]
    public class UsuarioEntity
    {
        [Key, Required]
        public int IdUsuario { get; set; }
        public string Nome { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Senha { get; set; } = default!;
    }
}
