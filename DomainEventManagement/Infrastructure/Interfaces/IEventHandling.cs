namespace Common.Interfaces
{
    public interface IEventHandling<T> where T : IDomainEvent
    {
        void Handler(T args);
    }
}
