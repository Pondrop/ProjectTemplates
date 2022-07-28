using PROJECT_NAME.Domain.Events;

namespace PROJECT_NAME.Application.Interfaces;

public interface IDaprService
{
    Task<bool> InvokeServiceAsync(string appId, string methodName, object? data = null);

    Task<bool> SendEventsAsync(string eventGridTopic, IEnumerable<IEvent> events);
}