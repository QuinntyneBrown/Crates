using System;
using System.Collections.Generic;

namespace Crates.Api.Features
{
    public class TrackDto
    {
        public Guid TrackId { get; set; }
        public string Name { get; private set; }
        public List<ArtistDto> Artists { get; private set; } = new();
        public List<PlaylistDto> Playlists { get; private set; } = new();
        public string Spotify { get; private set; }
        public string AppleMusic { get; private set; }
        public Guid CoverArtDigitalAssetId { get; private set; }
    }
}
