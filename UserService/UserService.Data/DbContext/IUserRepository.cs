

namespace UserService.Data.DbContext
{
    public interface IUserRepository
    {
        void Add(UserVO usuarioVO);
        IEnumerable<UsuarioVO> GetAll();
        UsuarioVO Find(long id);
        void Remove(long id);
        void Update(UsuarioVO usuario);
    }
}
