using AutoMapper;
using UserService.Domain.Entities;

namespace UserService.Application.Users.Command.CreateUser
{
    public class CreateUserProfile : Profile
    {
        public CreateUserProfile()
        {
            CreateMap<CreateUserCommand, User>()
                .ForMember(dest => dest.contactInfo, opt => opt.MapFrom(src => src.Contact));
            
            CreateMap<User, CreateUserResult>()
            .ForMember(dest => dest.Contact, opt => opt.MapFrom(src => src.contactInfo));
        }
    }
}
