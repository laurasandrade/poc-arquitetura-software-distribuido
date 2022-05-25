namespace poc.pos.arquiteturasoftwaredistribuido.api.Domain.Model.Request
{
    public class LoginRequest
    {
        public string Email { get; set; } = default!;
        public string Senha { get; set; } = default!;
    }
}
