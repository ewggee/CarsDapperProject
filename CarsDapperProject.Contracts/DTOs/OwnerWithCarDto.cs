namespace CarsDapperProject.Contracts.DTOs;

public class OwnerWithCarDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }

    public List<CarWithBrandDto> Cars { get; set; }
}
