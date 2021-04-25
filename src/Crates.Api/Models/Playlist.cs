using System;
using System.Collections.Generic;

namespace Crates.Api.Models
{
    public class Playlist
    {
        public Guid PlaylistId { get; set; }
        public List<Song> Songs { get; private set; } = new();
    }
}
