using AuthenticationService.Domain.Entities;
using AuthenticationService.Domain.Interfaces.Repositories;
using AuthenticationService.Domain.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace AuthenticationService.Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _usersRepository;

        public TokenService(IConfiguration configuration, IUserRepository usersRepository)
        {
            _configuration = configuration;
            _usersRepository = usersRepository;
        }

        public string GenerateToken(User user)
        {
            SymmetricSecurityKey secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"] ?? string.Empty));
            int hoursToExpireToken = int.Parse(_configuration["JWT:HoursToExpireToken"] ?? "");
            SigningCredentials signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            Claim[] claims =
            [
                 new Claim(ClaimTypes.Name, user.Name),
                 new Claim(ClaimTypes.Role, user.Role.ToString())
             ];



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
