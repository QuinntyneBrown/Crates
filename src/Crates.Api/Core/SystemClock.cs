using System;

namespace Crates.Api.Core
{
    public class SystemClock : IClock
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
