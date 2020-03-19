using MediatR;
using Domain.Bus;
using Domain.Commands;
using Domain.Events;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus
{
    public sealed class RabbitMqBus : IEventBus
    {
        private const string Hostname = "localhost";
        private readonly IMediator _mediator;
        private readonly Dictionary<string, List<Type>> _handlers;
        private readonly List<Type> _eventTypes;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public RabbitMqBus(IMediator mediator, IServiceScopeFactory serviceScopeFactory)
        {
            _mediator = mediator;
            _serviceScopeFactory = serviceScopeFactory;
            _handlers = new Dictionary<string, List<Type>>();
            _eventTypes = new List<Type>();
        }

        public Task SendCommand<TCommand>(TCommand command) where TCommand : Command
        {
            return _mediator.Send(command);
        }

        public void Publish<TEvent>(TEvent @event) where TEvent : Event
        {
            var factory = new ConnectionFactory() { HostName = Hostname };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    var eventName = @event.GetType().Name;
                    var queue = channel.QueueDeclare(eventName, false, false, false, null);

                    var message = JsonConvert.SerializeObject(@event);
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish("", eventName, null, body);
                }
            }
        }

        public void Subscribe<TEvent, THandler>()
            where TEvent : Event
            where THandler : IEventHandler
        {
            var eventName = typeof(TEvent).Name;
            var handlerType = typeof(THandler);

            if (!_eventTypes.Contains(typeof(TEvent)))
                _eventTypes.Add(typeof(TEvent));

            if (!_handlers.ContainsKey(eventName))
                _handlers.Add(eventName, new List<Type>());

            if (_handlers[eventName].Any(h => h.GetType() == handlerType))
                throw new ArgumentException($"Handler Type {handlerType.Name} already registered for {eventName}", nameof(handlerType));

            _handlers[eventName].Add(handlerType);

            StartBasicConsume<TEvent>();
        }

        private void StartBasicConsume<TEvent>() where TEvent : Event
        {
            var factory = new ConnectionFactory()
            {
                HostName = Hostname,
                DispatchConsumersAsync = true
            };
            var connection = factory.CreateConnection();

            var channel = connection.CreateModel();
            var eventName = typeof(TEvent).Name;
            var queue = channel.QueueDeclare(eventName, false, false, false, null);

            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.Received += Consumer_Received;
            channel.BasicConsume(eventName, true, consumer);
        }

        private async Task Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            var eventName = e.RoutingKey;
            var message = Encoding.UTF8.GetString(e.Body);

            try
            {
                await ProcessEvent(eventName, message).ConfigureAwait(false);
            }
            catch (Exception)
            {

            }
        }

        private async Task ProcessEvent(string eventName, string message)
        {
            if (_handlers.ContainsKey(eventName))
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var subscriptions = _handlers[eventName];
                    foreach (var sub in subscriptions)
                    {
                        var handler = scope.ServiceProvider.GetService(sub);
                        if (handler == null)
                            continue;
                        var eventType = _eventTypes.SingleOrDefault(t => t.Name == eventName);
                        var @event = JsonConvert.DeserializeObject(message, eventType);
                        var concreteType = typeof(IEventHandler<>).MakeGenericType(eventType);

                        await (Task)concreteType.GetMethod("Handle").Invoke(handler, new object[] { @event });
                    }
                }
            }
        }
    }
}
