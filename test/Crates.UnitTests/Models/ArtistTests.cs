using Crates.Api.Models;
using Xunit;

namespace Crates.Models.UnitTests
{
    public class ArtistTests { 
    
        [Fact]
        public void Constructor()
        {
            var actual = CreateArtist();
        }

        public Artist CreateArtist()
        {
            return new();
        }
    }
}
