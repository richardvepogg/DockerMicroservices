﻿namespace UserService.WebApi.Features.Users.DeleteUser
{
    public class DeleteUserProfile : Profile
    {
        public DeleteUserProfile()
        {
            CreateMap<int, DeleteUserCommand>()
                .ConstructUsing(id => new DeleteUserCommand(id));
        }
    }
}