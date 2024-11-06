using Autenticacao.AcessoDados.AcessoBanco;
using Autenticacao.Dominio.Entidades;
using Autenticacao.Dominio.ValueObjects;
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

        public string GenerateToken(UsuarioVO usuario)
        {
            var userDataBase = _usuariosRepository.Find(usuario);
            if (userDataBase == null)
                return null;

            SymmetricSecurityKey secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"] ?? string.Empty));
            int hoursToExpireToken = int.Parse(_configuration["JWT:HoursToExpireToken"]);
            SigningCredentials signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

             Claim[] claims = new[]
             {
                 new Claim(ClaimTypes.Name, usuario.nmUsuario),
                 new Claim(ClaimTypes.Role, usuario.nmCargo)
             };



            var jwtSecurityToken = new JwtSecurityToken(
        issuer: _configuration["JWT:Issuer"],
        audience: _configuration["JWT:Audience"],
        claims: claims,
        expires: DateTime.UtcNow.AddHours(hoursToExpireToken),
        signingCredentials: signingCredentials
    );


            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }

    }
}
