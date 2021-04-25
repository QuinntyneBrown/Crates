using System;
using System.Collections.Generic;

namespace Crates.Api.Models
{
    public class Playlist
    {
        public Guid PlaylistId { get; private set; }
        public DateTime Created { get; private set; } = DateTime.UtcNow;
        public DateTime Released { get; private set; }
        public List<Song> Songs { get; private set; } = new();
        public void Release()
        {
            Released = DateTime.UtcNow;
        }
    }
}
