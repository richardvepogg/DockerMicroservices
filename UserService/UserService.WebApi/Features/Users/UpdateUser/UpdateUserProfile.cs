﻿
using AutoMapper;
using UserService.Application.Users.Command.UpdateUser;

namespace UserService.WebApi.Features.Users.UpdateUser
{
    public class UpdateUserProfile : Profile
    {
        public UpdateUserProfile()
        {
            CreateMap<UpdateUserRequest, UpdateUserCommand>();
            CreateMap<UpdateUserResult, UpdateUserResponse>()
             .ForMember(dest => dest.Contact, opt => opt.MapFrom(src => src.Contact));
        }
    }
}
