
using AutoMapper;
using UserService.Application.Users.Command.CreateUser;
using UserService.Application.Users.Queries.GetUser;
using UserService.WebApi.Features.Users.CreateUser;

namespace UserService.WebApi.Features.Users.GetUser
{
    public class GetUserProfile : Profile
    {
        public GetUserProfile()
        {
            CreateMap<int, UserService.Application.Users.Queries.GetUser.GetUserQuerie>()
     .ConstructUsing(id => new UserService.Application.Users.Queries.GetUser.GetUserQuerie(id))
              .ForAllMembers(opt => opt.Ignore());

            CreateMap<GetUserResult, GetUserResponse>()
.ForMember(dest => dest.Contact, opt => opt.MapFrom(src => src.Contact));
        }
    }

}
