using Autenticacao.Dominio.Entidades;
using Autenticacao.Negocio.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
        private static IResult Autenticar(Usuario usuario, ITokenService _tokenService)
        {
            try
            {
                string token = _tokenService.GenerateToken(usuario);

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
