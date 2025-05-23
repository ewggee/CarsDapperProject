namespace CarsDapperProject.Domain.Entities;

public class Brand : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }

    public List<Car> Cars { get; set; } = [];
}
