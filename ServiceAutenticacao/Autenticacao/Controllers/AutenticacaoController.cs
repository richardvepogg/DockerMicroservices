using Autenticacao.Dominio.ValueObjects;
using Autenticacao.Negocio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Autenticacao.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public static class AutenticacaoController
    {
        public static void ConfigureApi(this WebApplication app)
        {
            app.MapPost("/Autenticar", Autenticar);
        }

        [HttpPost]
        private static IResult Autenticar(UsuarioVO usuarioVO, ITokenService _tokenService)
        {
            try
            {
                string token = _tokenService.GenerateToken(usuarioVO);

                if (string.IsNullOrWhiteSpace(token))
                    return Results.Unauthorized();

                return Results.Ok(token);
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

    }

}
