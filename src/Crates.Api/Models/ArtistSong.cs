using System;

namespace Crates.Api.Models
{
    public class ArtistSong
    {
        public Guid ArtistId { get; private set; }
        public Guid SongId { get; private set; }
        public Artist Artist { get; private set; }
        public Song Song { get; private set; }
    }
}
