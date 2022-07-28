namespace PROJECT_NAME.Domain.Events.User;

public record UpdateEmail(string Email) : EventPayload;