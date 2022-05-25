namespace poc.pos.arquiteturasoftwaredistribuido.api.Domain.Model.Infra
{
    public class TokenConfigurations
    {
        public string Audience { get; set; } = default!;
        public string Issuer { get; set; } = default!;
        public int Seconds { get; set; }
    }
}
