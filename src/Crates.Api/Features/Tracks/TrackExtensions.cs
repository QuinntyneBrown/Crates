using System;
using Crates.Api.Models;

namespace Crates.Api.Features
{
    public static class TrackExtensions
    {
        public static TrackDto ToDto(this Track track)
        {
            return new ()
            {
                TrackId = track.TrackId
            };
        }
        
    }
}
