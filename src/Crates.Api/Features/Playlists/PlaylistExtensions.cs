using System;
using Crates.Api.Models;

namespace Crates.Api.Features
{
    public static class PlaylistExtensions
    {
        public static PlaylistDto ToDto(this Playlist playlist)
        {
            return new()
            {
                PlaylistId = playlist.PlaylistId
            };
        }

    }
}
