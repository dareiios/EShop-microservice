namespace BuildingBlocks.Messaging.Events
{
    //???
    //standart structure for all events 
    public record IntegrationEvent
    {
        public Guid Id => Guid.NewGuid();
        public DateTime OccurredOn => DateTime.Now;
        public string EventType => GetType().AssemblyQualifiedName;
    }
}
