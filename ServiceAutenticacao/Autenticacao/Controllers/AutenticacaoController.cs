using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Autenticacao.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutenticacaoController 
    {
        public static void ConfigureApi(this WebApplication app)
        {
            app.MapPost("/Autenticar", Autenticar);
        }


    }
}
