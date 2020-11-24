using System;
using System.Collections.Generic;

namespace Common.Interfaces
{
    public interface IContainer
    {
        object GetService(Type serviceType);
        IEnumerable<object> GetServices(Type serviceType);
    }
}
