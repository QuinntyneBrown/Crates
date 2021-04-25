using System;
using System.Collections.Generic;

namespace Crates.Api.Models
{
    public class Song
    {
        public Guid SongId { get; private set; }
        public List<Artist> Artists { get; private set; } = new();
        public List<Playlist> Playlists { get; private set; } = new();
        public string Spotify { get; private set; }
        public string AppleMusic { get; private set; }
        public Guid BoxArtDigitalAssetId { get; private set; }

    }
}
