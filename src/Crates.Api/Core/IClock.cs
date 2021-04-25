using System;

namespace Crates.Api.Core
{
    public interface IClock
    {
        DateTime UtcNow { get; }
    }
}
