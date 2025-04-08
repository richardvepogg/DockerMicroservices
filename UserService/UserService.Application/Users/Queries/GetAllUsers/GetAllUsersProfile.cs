
namespace UserService.Application.Users.Queries.GetAllUsers
{
    using AutoMapper;
    using UserService.Domain.Entities;

    public class GetAllUsersProfile : Profile
    {
        public GetAllUsersProfile()
        {
            CreateMap<User, GetAllUsersResult.GetAllUserResult>()
                .ForMember(dest => dest.Contact, opt => opt.MapFrom(src => src.contactInfo));
        }
    }


}
