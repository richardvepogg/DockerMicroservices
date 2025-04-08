using AutoMapper;
using UserService.Application.Users.Queries.GetAllUsers;

namespace UserService.WebApi.Features.Users.GetAllUsers
{
    public class GetAllUsersProfile : Profile
    {
        public GetAllUsersProfile()
        {
            CreateMap<GetAllUsersResult, GetAllUsersResponse>()
            .ForMember(dest => dest.GetAllUsersResponses, opt => opt.MapFrom(src => src.GetAllUsersResults));

            CreateMap<GetAllUsersResult.GetAllUserResult, GetAllUsersResponse.GetAllUserResponse>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.id));
        }
    }
}
