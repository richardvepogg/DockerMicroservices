

using Usuarios.Dominio.Entidades;

namespace Usuarios.AcessoDados.AcessoBanco
{
    public interface IUsuariosRepository
    {
        void Add(Usuario usuario);
        IEnumerable<Usuario> GetAll();
        Usuario Find(long id);
        void Remove(long id);
        void Update(Usuario usuario);
    }
}
