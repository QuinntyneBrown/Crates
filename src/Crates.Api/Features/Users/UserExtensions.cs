using System;
using Crates.Api.Models;

namespace Crates.Api.Features
{
    public static class UserExtensions
    {
        public static UserDto ToDto(this User user)
        {
            return new ()
            {
                UserId = user.UserId
            };
        }
        
    }
}
