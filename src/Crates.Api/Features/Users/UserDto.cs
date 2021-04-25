using System;

namespace Crates.Api.Features
{
    public class UserDto
    {
        public static readonly UserDto Anonymous = new();
        public Guid? UserId { get; set; }
        public string Username { get; set; }
        public Guid AvatarDigitalAssetId { get; set; }
    }
}
