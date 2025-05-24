namespace CarsDapperProject.Domain.QueryModels.Car;

public class CarWithOwner
{
    public int Id { get; set; }
    public string Model { get; set; }

    public int OwnerId { get; set; }
    public string OwnerName { get; set; }
}
