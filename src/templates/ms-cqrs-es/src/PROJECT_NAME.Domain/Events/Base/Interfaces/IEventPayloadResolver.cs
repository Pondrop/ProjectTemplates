namespace PROJECT_NAME.Domain.Events;

public interface IEventTypePayloadResolver
{
    Type? GetEventPayloadType(string streamType, string typeName);
}