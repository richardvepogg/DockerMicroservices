using AuthenticationService.Domain.Entities;
using AutoMapper;

namespace AuthenticationService.Application.Users.Queries
{
    public class GetUserProfile : Profile
    {
        public GetUserProfile()
        {
            CreateMap<GetUserQuerie, User>();
            CreateMap<User, GetUserResult>()
            .ForMember(dest => dest.token, opt => opt.Ignore());
        }
    }
}
