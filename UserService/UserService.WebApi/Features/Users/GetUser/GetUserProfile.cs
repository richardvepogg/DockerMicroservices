
using AutoMapper;

namespace UserService.WebApi.Features.Users.GetUser
{
    public class GetUserProfile : Profile
    {
        public GetUserProfile()
        {
            CreateMap<int, UserService.Application.Users.Queries.GetUser.GetUserQuerie>()
     .ConstructUsing(id => new UserService.Application.Users.Queries.GetUser.GetUserQuerie(id));
        }
    }
}
