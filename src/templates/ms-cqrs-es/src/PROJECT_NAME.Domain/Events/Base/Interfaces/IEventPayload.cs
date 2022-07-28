using Newtonsoft.Json.Linq;

namespace PROJECT_NAME.Domain.Events;

public interface IEventPayload
{
    DateTime CreatedUtc { get; }
}