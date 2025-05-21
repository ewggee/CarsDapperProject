namespace CarsDapperProject.Domain.Exceptions;

public abstract class EntityNotFoundException(string message) : Exception(message)
{ }
