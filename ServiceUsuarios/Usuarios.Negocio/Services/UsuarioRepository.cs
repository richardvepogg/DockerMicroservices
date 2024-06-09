
using Usuarios.AcessoDados.Contexto;
using Usuarios.AcessoDados.AcessoBanco;
using Usuarios.Dominio.Entidades;

namespace Usuarios.Negocio.Services
{
    public class UsuariosRepository : IUsuariosRepository
    {

        private readonly UsuarioDbContext _contexto;

        public UsuariosRepository(UsuarioDbContext ctx)
        {
            _contexto = ctx;
        }

        public void Add(Usuario usuario)
        {
            _contexto.Usuarios.Add(usuario);
            _contexto.SaveChanges();
        }

        public Usuario Find(long id)
        {
            return _contexto.Usuarios.FirstOrDefault(u => u.idusuario == id)!;
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _contexto.Usuarios.ToList();
        }

        public void Remove(long id)
        {
            var entity = _contexto.Usuarios.First(u => u.idusuario
             == id);
            _contexto.Usuarios.Remove(entity);
            _contexto.SaveChanges();
        }

        public void Update(Usuario usuario)
        {
            _contexto.Usuarios.Update(usuario);
            _contexto.SaveChanges();
        }
    }
}
