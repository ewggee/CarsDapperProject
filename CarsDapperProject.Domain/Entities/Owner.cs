using CarsDapperProject.Application.Abstractions;

namespace CarsDapperProject.Domain.Entities;

public class Owner : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }

    public List<Car> CarsOwned { get; set; } = [];
}
