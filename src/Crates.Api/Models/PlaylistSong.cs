using System;

namespace Crates.Api.Models
{
    public class PlaylistSong
    {
        public Guid PlaylistId { get; private set; }
        public Guid SongId { get; private set; }
        public Playlist Playlist { get; private set; }
        public Song Song { get; private set; }
    }
}
