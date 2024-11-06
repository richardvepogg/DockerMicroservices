

using Usuarios.Dominio.Entidades;
using Usuarios.Dominio.ValueObjects;

namespace Usuarios.AcessoDados.AcessoBanco
{
    public interface IUsuariosRepository
    {
        void Add(UsuarioVO usuarioVO);
        IEnumerable<UsuarioVO> GetAll();
        UsuarioVO Find(long id);
        void Remove(long id);
        void Update(UsuarioVO usuario);
    }
}
