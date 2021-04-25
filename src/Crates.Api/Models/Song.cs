using System;
using System.Collections.Generic;

namespace Crates.Api.Models
{
    public class Song
    {
        public Guid SongId { get; private set; }
        public Guid ArtistId { get; private set; }
        public List<Song> Songs { get; private set; } = new();
    }
}
