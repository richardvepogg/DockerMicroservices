using AutoMapper;
using UserService.Application.Users.Queries.GetAllUsers;

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
