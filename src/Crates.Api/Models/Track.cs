using System;
using System.Collections.Generic;

namespace Crates.Api.Models
{
    public class Track
    {
        public Guid TrackId { get; private set; }
        public string Name { get; private set; }
        public List<Artist> Artists { get; private set; } = new();
        public List<Playlist> Playlists { get; private set; } = new();
        public string Spotify { get; private set; }
        public string AppleMusic { get; private set; }
        public Guid CoverArtDigitalAssetId { get; private set; }
    }
}
