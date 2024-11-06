using Autenticacao.AcessoDados.AcessoBanco;
using Autenticacao.AcessoDados.Contexto;
using Autenticacao.Dominio.Entidades;
using Autenticacao.Dominio.ValueObjects;
using AutoMapper;


namespace Autenticacao.Negocio.Services
{
    public class UsuariosRepository : IUsuariosRepository
    {

        private readonly UsuarioDbContext _contexto;
        private readonly IMapper _mapper;


        public UsuariosRepository(UsuarioDbContext contexto, IMapper mapper)
        {
            _contexto = contexto;
            _mapper = mapper;
        }


        public UsuarioVO Find(UsuarioVO usuariovo)
        {
            var usuario = _contexto.Usuarios
                .FirstOrDefault(u => u.nmusuario == usuariovo.nmUsuario && u.senha == usuariovo.senha);

            if (usuario == null)
                return null;

            return _mapper.Map<UsuarioVO>(usuario);
        }
    }
}
