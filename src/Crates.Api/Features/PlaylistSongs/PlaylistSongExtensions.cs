using System;
using Crates.Api.Models;

namespace Crates.Api.Features
{
    public static class PlaylistSongExtensions
    {
        public static PlaylistSongDto ToDto(this PlaylistSong playlistSong)
        {
            return new ()
            {
                PlaylistSongId = playlistSong.PlaylistSongId
            };
        }
        
    }
}
