using Microsoft.AspNetCore.Mvc;
using Usuarios.AcessoDados.AcessoBanco;
using Usuarios.Dominio.Entidades;
using Usuarios.Negocio.Services;


namespace Usuarios.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public static class UsuariosController
    {

        public static void ConfigureApi(this WebApplication app)
        {
            app.MapGet("/Usuario", ObterUsuarios);
            app.MapGet("/Usuario/{id}", ObterUsuario);
            app.MapPost("/Usuario", Inserirusuario);
            app.MapPut("/Usuario", AtualizarUsuario);
            app.MapDelete("/Usuario/{id}", DeletarUsuario);

        }

        [HttpGet]
        private static IResult ObterUsuarios(UsuariosRepository data)
        {
            try
            {
                return Results.Ok(data.GetAll());
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        [HttpGet("{id}")]
        private static IResult ObterUsuario(int id, IUsuariosRepository data)
        {
            try
            {
                var usuario = data.Find(id);
                if (usuario == null) return Results.NotFound();

                return Results.Ok(usuario);
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        [HttpPost]
        private static IResult Inserirusuario(Usuario usuario, IUsuariosRepository data)
        {
            try
            {
                data.Add(usuario);
                return Results.Ok("O usuário foi inserido com sucesso!");
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        [HttpPut]
        private static IResult AtualizarUsuario(Usuario usuario, IUsuariosRepository data)
        {
            try
            {
                data.Update(usuario);

                return Results.Ok("O usuário foi atualizado com sucesso!");
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        [HttpDelete]
        private static IResult DeletarUsuario(int id, IUsuariosRepository data)
        {
            try
            {
                data.Remove(id);

                return Results.Ok("O usuário foi deletado com sucesso!");
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }
    }
}
