namespace CarsDapperProject.Domain.Exceptions.Owner;

public class OwnerNotFoundException(int id) : EntityNotFoundException("Владелец", id)
{ }
