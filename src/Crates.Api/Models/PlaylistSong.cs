using System;

namespace Crates.Api.Models
{
    public class PlaylistSong
    {
        public Guid PlaylistSongId { get; private set; }
        public Guid PlaylistId { get; private set; }
        public Guid SongId { get; private set; }
        public PlaylistSong()
        {

        }
    }
}
