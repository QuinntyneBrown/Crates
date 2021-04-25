using Crates.Api.Models;
using Xunit;

namespace Crates.UnitTests.Models
{
    public class UserTests
    {
        [Fact]
        public void Constructor()
        {
            var sut = CreateUser();
        }

        private User CreateUser()
        {
            return new ();
        }
    }
}
