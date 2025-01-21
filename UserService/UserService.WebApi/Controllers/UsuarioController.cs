using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace UserService.Controllers
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

        [Authorize(Roles = "Employe, Manager")]
        [HttpGet]
        private static IResult ObterUsuarios(IUsuariosRepository data)
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

        [Authorize(Roles = "Employe, Manager")]
        [HttpGet("{id}")]
        private static IResult ObterUsuario(int id, IUsuariosRepository data)
        {
            try
            {
                UsuarioVO usuario = data.Find(id);
                if (usuario == null) return Results.NotFound();

                return Results.Ok(usuario);
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        [Authorize(Roles = "Manager")]
        [HttpPost]
        private static IResult Inserirusuario(UsuarioVO usuarioVO, IUsuariosRepository data)
        {
            try
            {
                data.Add(usuarioVO);
                return Results.Ok("O usuário foi inserido com sucesso!");
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        [Authorize(Roles = "Manager")]
        [HttpPut]
        private static IResult AtualizarUsuario(UsuarioVO usuarioVO, IUsuariosRepository data)
        {
            try
            {
                data.Update(usuarioVO);

                return Results.Ok("O usuário foi atualizado com sucesso!");
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        [Authorize(Roles = "Manager")]
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
