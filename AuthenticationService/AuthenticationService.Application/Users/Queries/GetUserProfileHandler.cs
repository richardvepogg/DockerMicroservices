using AuthenticationService.Domain.Entities;
using AutoMapper;

namespace AuthenticationService.Application.Users.Queries
{
    public class GetUserProfileHandler : Profile
    {
        public GetUserProfileHandler()
        {
            CreateMap<GetUserQuerie, User>();
            CreateMap<User, GetUserResult>()
            .ForMember(dest => dest.token, opt => opt.Ignore());
        }
    }
}
