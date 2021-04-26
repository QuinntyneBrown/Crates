using Crates.Api.Models;
using Xunit;

namespace Crates.UnitTests
{
    public class SongTests
    {
        [Fact]
        public void Constuctor()
        {
            var actual = CreateSong();
        }
        
        public Song CreateSong()
        {
            return new();
        }
        
    }
}
