using AutoMapper;
using UserService.Application.Users.Command.CreateUser;
using UserService.Application.Users.Queries.GetUser;
using UserService.WebApi.Features.Users.GetUser;


namespace UserService.WebApi.Features.Users.CreateUser
{
    public class CreateUserProfile : Profile
    {
        public CreateUserProfile()
        {
            CreateMap<CreateUserRequest, CreateUserCommand>();

            CreateMap<CreateUserResult, CreateUserResponse>()
      .ForMember(dest => dest.Contact, opt => opt.MapFrom(src => src.Contact));

        }
    }
}
