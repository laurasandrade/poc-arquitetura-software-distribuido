using System;

namespace poc.pos.arquiteturasoftwaredistribuido.api.Domain.Model.Response
{
    public class LoginResponse
    {
        public bool authenticated { get; set; }
        public DateTime created { get; set; }
        public DateTime expiration { get; set; }
        public string? accessToken { get; set; }
        public string message { get; set; } = default!;
    }
}
