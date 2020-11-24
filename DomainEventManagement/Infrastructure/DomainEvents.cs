using System.Threading.Tasks;
using Common.Interfaces;

namespace Common
{
    public static class DomainEvents
    {
        public static IContainer Container { get; set; }

        public static void Raise<T>(T args) where T : IDomainEvent
        {
            try
            {
                if (Container == null) return;
                foreach (var handler in Container.GetServices(typeof(IEventHandling<T>)))
                    Task.Run(() => ((IEventHandling<T>) handler).Handler(args));
            }
            catch
            {
                //throw;
            }
        }
    }
}
