using System;
using System.Collections.Generic;
using System.Linq;

namespace Crates.Api.Features
{
    public class TrackDto
    {
        public Guid? TrackId { get; set; }
        public string Name { get; set; }
        public string AlbumName => Album.Name;
        public string ArtistName => Artists.First().Name; 
        public List<ArtistDto> Artists { get; set; } = new();
        public List<PlaylistDto> Playlists { get; set; } = new();
        public string Spotify { get; set; }
        public string AppleMusic { get; set; }
        public AlbumDto Album { get; set; }
        public Guid CoverArtDigitalAssetId { get; set; }
    }
}
