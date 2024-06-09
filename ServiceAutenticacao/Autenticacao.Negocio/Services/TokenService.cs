using Autenticacao.AcessoDados.AcessoBanco;
using Autenticacao.Dominio.Entidades;
using Autenticacao.Negocio.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Autenticacao.Negocio.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly IUsuariosRepository _usuariosRepository;

        public TokenService(IConfiguration configuration, IUsuariosRepository usuariosRepository)
        {
            _configuration = configuration;
            _usuariosRepository = usuariosRepository;
        }

        public string GenerateToken(Usuario usuario)
        {
            var userDataBase = _usuariosRepository.Find(usuario);
            if (userDataBase != null)
                return null;

            SymmetricSecurityKey secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"] ?? null));

            int hoursToExpireToken = int.Parse(_configuration["JWT:HoursToExpireToken"]);

            SigningCredentials signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                claims: new[]
                {
                    new Claim(type: ClaimTypes.Name,usuario.nmusuario),
                    new Claim(type: ClaimTypes.Role,usuario.nmcargo)
                },
                expires: DateTime.UtcNow.AddHours(hoursToExpireToken));

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }
    }
}
