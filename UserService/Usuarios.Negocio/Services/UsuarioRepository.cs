
using Usuarios.AcessoDados.Contexto;
using Usuarios.AcessoDados.AcessoBanco;
using Usuarios.Dominio.Entidades;
using Usuarios.Dominio.ValueObjects;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace Usuarios.Negocio.Services
{
    public class UsuariosRepository : IUsuariosRepository
    {

        private readonly UsuarioDbContext _contexto;
        private readonly IMapper _mapper;


        public UsuariosRepository(UsuarioDbContext ctx, IMapper mapper)
        {
            _contexto = ctx;
            _mapper = mapper;

        }

        public void Add(UsuarioVO usuarioVO)
        {
            _contexto.Usuarios.Add(_mapper.Map<Usuario>(usuarioVO));
            _contexto.SaveChanges();
        }

        public UsuarioVO Find(long id)
        {
            Usuario usuario = _contexto.Usuarios.FirstOrDefault(u => u.idusuario == id)!;

            if (usuario == null)
                return null;

            return _mapper.Map<UsuarioVO>(usuario);
        }

        public IEnumerable<UsuarioVO> GetAll()
        {
            return _contexto.Usuarios
                           .ProjectTo<UsuarioVO>(_mapper.ConfigurationProvider)
                           .ToList();
        }

        public void Remove(long id)
        {
            Usuario usuario = _contexto.Usuarios.FirstOrDefault(u => u.idusuario == id);

            if (usuario == null)
                return;

            _contexto.Usuarios.Remove(usuario);
            _contexto.SaveChanges();
        }

        public void Update(UsuarioVO usuarioVO)
        {
            var usuario = _contexto.Usuarios.FirstOrDefault(u => u.idusuario == usuarioVO.idUsuario);

            if (usuario == null)
                return;

            _mapper.Map(usuarioVO, usuario);
            _contexto.SaveChanges();
        }

    }
}
