﻿using AutoMapper;
using UserService.Domain.Entities;

namespace UserService.Application.Users.Queries.GetUser
{
    public class GetUserProfile : Profile
    {
        public GetUserProfile()
        {
            CreateMap<User, GetUserResult>();
        }
    }
}