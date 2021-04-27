using System;
using System.Collections.Generic;

namespace Crates.Api.Models
{
    public class Album
    {
        public Guid AlbumId { get; private set; }
        public string Name { get; private set; }
        public AlbumType Type { get; private set; } = AlbumType.Album;
        public Guid GenreId { get; set; }
        public List<Track> Tracks { get; private set; } = new();
    }
}
