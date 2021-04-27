using System;

namespace Crates.Api.Models
{
    public class ArtistTrack
    {
        public Guid ArtistId { get; private set; }
        public Guid TrackId { get; private set; }
        public Artist Artist { get; private set; }
        public Track Track { get; private set; }
    }
}
