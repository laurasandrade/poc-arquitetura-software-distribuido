using Microsoft.IdentityModel.Tokens;
using poc.pos.arquiteturasoftwaredistribuido.api.Domain.Contract.Infrastructure.Repository;
using poc.pos.arquiteturasoftwaredistribuido.api.Domain.Contract.Service;
using poc.pos.arquiteturasoftwaredistribuido.api.Domain.Model.Entity;
using poc.pos.arquiteturasoftwaredistribuido.api.Domain.Model.Infra;
using poc.pos.arquiteturasoftwaredistribuido.api.Domain.Model.Request;
using poc.pos.arquiteturasoftwaredistribuido.api.Domain.Model.Response;
using poc.pos.arquiteturasoftwaredistribuido.api.Domain.Tools;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace poc.pos.arquiteturasoftwaredistribuido.api.Service
{
    public class LoginService : ILoginService
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly TokenConfigurations tokenConfigurations;
        private readonly SigningConfigurations signingConfigurations;

        public LoginService(IUsuarioRepository usuarioRepository, TokenConfigurations tokenConfigurations, SigningConfigurations signingConfigurations)
        {
            this.usuarioRepository = usuarioRepository;
            this.tokenConfigurations = tokenConfigurations;
            this.signingConfigurations = signingConfigurations;
        }
        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            var usuario = await usuarioRepository.GetFirstAsync(u => u.Email.Equals(request.Email, StringComparison.InvariantCultureIgnoreCase) && u.Senha.Equals(PasswordTools.Encrypt(request.Senha), StringComparison.InvariantCulture));

            // Credenciais Válidas
            if (usuario.Success)
            {
                return GerarToken(usuario.Data);
            }
            else
            {
                return new LoginResponse
                {
                    authenticated = false,
                    message = "Falha ao autenticar"
                };
            }
        }

        public async Task<LoginResponse> CadastrarAsync(UsuarioEntity usuarioEntity)
        {
            usuarioEntity.Senha = PasswordTools.Encrypt(usuarioEntity.Senha);
            var usuario = await usuarioRepository.InsertAsync(usuarioEntity);

            // Credenciais Válidas
            if (usuario.Success)
            {
                return GerarToken(usuario.Data);
            }
            else
            {
                return new LoginResponse
                {
                    authenticated = false,
                    message = "Ocorreu um erro ao cadastrar"
                };
            }
        }

        private LoginResponse GerarToken(UsuarioEntity usuario)
        {
            ClaimsIdentity identity = new ClaimsIdentity(
                new GenericIdentity(usuario.Email, "Login"),
                new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim("email", usuario.Email),
                        new Claim("nome", usuario.Nome)
                }
            );

            DateTime dataCriacao = DateTime.Now.ToUniversalTime();
            DateTime dataExpiracao = dataCriacao.AddSeconds(3600);

            var handler = new JwtSecurityTokenHandler();
            handler.TokenLifetimeInMinutes = (int)TimeSpan.FromSeconds(3600).TotalMinutes;
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = tokenConfigurations.Issuer,
                Audience = tokenConfigurations.Audience,
                SigningCredentials = signingConfigurations.SigningCredentials,
                Subject = identity,
                IssuedAt = dataCriacao,
                NotBefore = dataCriacao,
                Expires = dataExpiracao,

            });
            var token = handler.WriteToken(securityToken);

            return new LoginResponse
            {
                authenticated = true,
                created = dataCriacao,
                expiration = dataExpiracao,
                accessToken = token,
                message = "Bem vindo!"
            };
        }
    }
}
