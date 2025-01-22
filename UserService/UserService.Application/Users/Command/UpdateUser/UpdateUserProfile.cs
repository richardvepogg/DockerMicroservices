using AutoMapper;
using UserService.Domain.Entities;

namespace UserService.Application.Users.Command.UpdateUser
{
    public class UpdateUserProfile : Profile
    {
        public UpdateUserProfile()
        {
            CreateMap<UpdateUserCommand, User>();
            CreateMap<User, UpdateUserResult>();
        }
    }
}
