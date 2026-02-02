namespace Ordering.Domain.Abstraction
{
    public interface IAggregate<T> : IAggregate, IEntity<T>
    {
    }

    public interface IAggregate : IEntity
    {
        IReadOnlyList<IDomainEvent> DomainEvents { get; } //there will be IDomain event related objects
        IDomainEvent[] ClearDomainEvents();
    }
}
