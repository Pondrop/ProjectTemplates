using Newtonsoft.Json;

namespace PROJECT_NAME.Domain.Events;

public record EventPayload : IEventPayload
{
    public DateTime CreatedUtc { get; } = DateTime.UtcNow;
}