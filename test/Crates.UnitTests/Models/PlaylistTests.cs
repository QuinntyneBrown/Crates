using Crates.Api.Core;
using Crates.Api.Models;
using Xunit;

namespace Crates.UnitTests.Models
{
    public class PlaylistTests
    {
        [Fact]
        public void Contstructor()
        {
            var actual = CreatePlaylist();
        }

        public Playlist CreatePlaylist()
        {
            return new(new SystemClock().UtcNow);
        }
    }
}
