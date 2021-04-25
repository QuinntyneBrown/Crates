using System;
using System.Collections.Generic;

namespace Crates.Api.Models
{
    public class Artist
    {
        public Guid ArtistId { get; set; }
        public List<Song> Songs { get; set; }
    }
}
