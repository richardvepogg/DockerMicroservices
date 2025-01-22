namespace UserService.WebApi.Features.Users.GetAllUsers
{
    public class GetAllUsersProfile : Profile
    {
        public GetAllUsersProfile()
        {
            CreateMap<GetAllUsersResult, GetAllUsersResponse>();

        }
    }
}
