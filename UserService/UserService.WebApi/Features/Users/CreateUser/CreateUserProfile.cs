
using AutoMapper;
using UserService.Application.Users.Command.CreateUser;

namespace UserService.WebApi.Features.Users.CreateUser
{
    public class CreateUserProfile : Profile
    {
        public CreateUserProfile()
        {
            CreateMap<CreateUserRequest, CreateUserCommand>();
            CreateMap<CreateUserResult, CreateUserResponse>();
        }
    }
}
