using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuario.AcessoDados.AcessoBanco;
using Usuario.AcessoDados.Contexto;

namespace Usuario.Negocio.Services
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly UsuarioDbContext _contexto;

        public UsuarioRepository(UsuarioDbContext ctx)
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
