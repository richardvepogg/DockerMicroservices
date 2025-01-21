using AutoMapper;

namespace UserService.Application.Automapper
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
