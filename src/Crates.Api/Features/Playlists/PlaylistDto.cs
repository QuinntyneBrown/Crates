using System;
using System.Collections.Generic;

namespace Crates.Api.Features
{
    public class PlaylistDto
    {
        public Guid? PlaylistId { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime Released { get; set; }
        public List<TrackDto> Tracks { get; set; } = new();
        public string Spotify { get; set; }
        public Guid CoverArtDigitalAssetId { get; set; }

    }
}
