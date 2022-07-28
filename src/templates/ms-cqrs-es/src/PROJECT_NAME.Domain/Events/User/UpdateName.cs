namespace PROJECT_NAME.Domain.Events.User;

public record UpdateName(string FirstName, string LastName) : EventPayload;