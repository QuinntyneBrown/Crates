using System;
using System.Collections.Generic;

namespace Crates.Api.Models
{
    public class Artist
    {
        public Guid ArtistId { get; set; }
        public string Name { get; set; } 
        public List<Track> Tracks { get; set; }
    }
}
