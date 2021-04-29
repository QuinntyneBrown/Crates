using Crates.Api.Models;

namespace Crates.Api.Features
{
    public static class GenreExtensions
    {
        public static GenreDto ToDto(this Genre genre)
        {
            return new ()
            {
                GenreId = genre.GenreId
            };
        }
    }
}
