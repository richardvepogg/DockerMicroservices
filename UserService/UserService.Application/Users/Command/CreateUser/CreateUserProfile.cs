using AutoMapper;
using UserService.Domain.Entities;

namespace UserService.Application.Users.Command.CreateUser
{
    public class CreateUserProfile : Profile
    {
        public CreateUserProfile()
        {
            CreateMap<CreateUserCommand, User>();
            CreateMap<User, CreateUserResult>();
        }
    }
}
