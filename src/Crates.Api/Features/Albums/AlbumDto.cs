using Crates.Api.Models;
using System;

namespace Crates.Api.Features
{
    public class AlbumDto
    {
        public Guid AlbumId { get; set; }
        public string Name { get; set; }
        public AlbumType Type { get; set; }
    }
}
