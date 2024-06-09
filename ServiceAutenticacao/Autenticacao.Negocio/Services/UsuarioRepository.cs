using Autenticacao.AcessoDados.AcessoBanco;
using Autenticacao.AcessoDados.Contexto;
using Autenticacao.Dominio.Entidades;


namespace Autenticacao.Negocio.Services
{
    public class UsuariosRepository : IUsuariosRepository
    {

        private readonly UsuarioDbContext _contexto;

        public UsuariosRepository(UsuarioDbContext ctx)
        {
            _contexto = ctx;
        }

        public Usuario Find(Usuario usuario)
        {
            return _contexto.Usuarios.FirstOrDefault(u => u.nmusuario == usuario.nmusuario && u.senha == usuario.senha);
        }


    }
}
