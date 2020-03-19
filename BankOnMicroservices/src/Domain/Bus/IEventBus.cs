using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Commands;
using Domain.Events;

namespace Domain.Bus
{
    public interface IEventBus
    {
        Task SendCommand<TCommand>(TCommand command) where TCommand : Command;
        void Publish<TEvent>(TEvent @event) where TEvent : Event;
        void Subscribe<TEvent, THandler>()
            where TEvent : Event
            where THandler : IEventHandler;
    }
}
