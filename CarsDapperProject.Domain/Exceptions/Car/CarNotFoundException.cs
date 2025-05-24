namespace CarsDapperProject.Domain.Exceptions.Car;

public class CarNotFoundException(int id) 
    : EntityNotFoundException("Автомобиль", id)
{
}
