using System;

namespace Crates.Api.Models
{
    public class PlaylistTrack
    {        
        public Guid PlaylistId { get; private set; }
        public Guid TrackId { get; private set; }
        public int Order { get; private set; }
        public Playlist Playlist { get; private set; }
        public Track Track { get; private set; }
    }
}
