using System;
using System.Collections.Generic;
using Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Helpers
{
    public class DomainEventsContainer : IContainer
    {
        private readonly ServiceProvider _serviceProvider;

        public DomainEventsContainer(ServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public object GetService(Type serviceType)
        {
            return _serviceProvider.GetService(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _serviceProvider.GetServices(serviceType);
        }
    }
}
