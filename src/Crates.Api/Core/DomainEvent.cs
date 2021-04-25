using MediatR;
using System;

namespace Crates.Api.Core
{
    public class DomainEvent : INotification
    {
        public DateTime Created { get; private set; } = DateTime.UtcNow;
    }
}
