namespace PROJECT_NAME.Domain.Events.User;

public record CreateUser(Guid Id, string FirstName, string LastName, string Email) : EventPayload;