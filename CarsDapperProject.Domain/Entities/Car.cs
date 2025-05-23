namespace CarsDapperProject.Domain.Entities;

public class Car : IEntity
{
    public int Id { get; set; }
    public string Model { get; set; }

    public int BrandId { get; set; }
    public Brand Brand { get; set; }

    public int? OwnerId { get; set; }
    public Owner? Owner { get; set; }
}
