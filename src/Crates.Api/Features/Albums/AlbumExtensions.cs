using System;
using Crates.Api.Models;

namespace Crates.Api.Features
{
    public static class AlbumExtensions
    {
        public static AlbumDto ToDto(this Album album)
        {
            return new ()
            {
                AlbumId = album.AlbumId
            };
        }
        
    }
}
