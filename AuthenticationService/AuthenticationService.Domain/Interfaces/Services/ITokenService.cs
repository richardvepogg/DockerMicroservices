using AuthenticationService.Domain.Entities;

namespace AuthenticationService.Domain.Interfaces.Services
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
