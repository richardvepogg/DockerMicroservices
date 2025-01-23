using AuthenticationService.Application.Users.Queries;
using AutoMapper;

namespace AuthenticationService.WebApi.Features.Users.GetUser
{
    public class GetUserProfile : Profile
    {
        public GetUserProfile()
        {
            CreateMap<GetUserRequest, GetUserQuerie>();
            CreateMap<GetUserResult, GetUserResponse>();

        }
    }
}
