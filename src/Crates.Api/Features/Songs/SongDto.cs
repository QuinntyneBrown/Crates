using System;
using System.Collections.Generic;

namespace Crates.Api.Features
{
    public class SongDto
    {
        public Guid? SongId { get; set; }
        public List<ArtistDto> Artists { get; set; }
        public List<PlaylistDto> Playlists { get; set; }
    }
}
