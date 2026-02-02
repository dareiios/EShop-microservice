using MediatR;

namespace Ordering.Domain.Abstraction
{
    // allows domain events to be dispatched through the mediatr handler
    // so we use mediatr handlers in order to handle these events using mediatr
    public interface IDomainEvent : INotification 
    {
        Guid EventId => Guid.NewGuid();
        public DateTime OccurredOn => DateTime.Now;
        public string EventType => GetType().AssemblyQualifiedName;//which class is throwing this event
    }
}
