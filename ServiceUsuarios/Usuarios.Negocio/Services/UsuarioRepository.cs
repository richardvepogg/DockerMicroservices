
using Usuarios.AcessoDados.Contexto;
using Usuarios.AcessoDados.AcessoBanco;
using Usuarios.Dominio.Entidades;

namespace Usuarios.Negocio.Services
{
    public class UsuariosRepository : IUsuariosRepository
    {

        private readonly UsuariosDbContext _contexto;

        public UsuariosRepository(UsuariosDbContext ctx)
        {
            _contexto = ctx;
        }

        public void Add(Usuario produto)
        {
            _contexto.Usuarios.Add(produto);
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

        public void Update(Usuario produto)
        {
            _contexto.Usuarios.Update(produto);
            _contexto.SaveChanges();
        }
    }
}
