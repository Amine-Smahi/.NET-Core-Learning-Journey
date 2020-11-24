using Application.EventHandlers;
using Application.Helpers;
using Common;
using Common.Interfaces;
using Domain.Events;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public class ResolverDependencies
    {
        public static void Resolve()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<IEventHandling<PatientCreated>, PatientCreatedHandler>();
            DomainEvents.Container = new DomainEventsContainer(serviceCollection.BuildServiceProvider());
        }
    }
}
