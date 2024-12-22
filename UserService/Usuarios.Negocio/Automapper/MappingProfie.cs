using AutoMapper;
using Usuarios.Dominio.Entidades;
using Usuarios.Dominio.ValueObjects;


namespace Usuarios.Negocio.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Usuario, UsuarioVO>();
            CreateMap<UsuarioVO, Usuario>();
        }
    }
}
