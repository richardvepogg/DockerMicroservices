
namespace UserService.WebApi.Features.Users.UpdateUser
{
    public class UpdateUserProfile : Profile
    {
        public UpdateUserProfile()
        {
            CreateMap<UpdateUserRequest, UpdateUserCommand>();
            CreateMap<UpdateUserResult, UpdateUserResponse>();
        }
    }
}
