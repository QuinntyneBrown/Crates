using Crates.Api.Models;

namespace Crates.Api.Features
{
    public static class ArtistExtensions
    {
        public static ArtistDto ToDto(this Artist artist)
        {
            return new()
            {
                ArtistId = artist.ArtistId,
                Name = artist.Name
            };
        }

    }
}
