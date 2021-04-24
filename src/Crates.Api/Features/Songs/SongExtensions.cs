using System;
using Crates.Api.Models;

namespace Crates.Api.Features
{
    public static class SongExtensions
    {
        public static SongDto ToDto(this Song song)
        {
            return new ()
            {
                SongId = song.SongId
            };
        }
        
    }
}
