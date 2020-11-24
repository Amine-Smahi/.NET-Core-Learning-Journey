using System;

namespace Common.Interfaces
{
    public interface IDomainEvent
    {
        DateTime DateOccurred { get; }
    }
}
