namespace CarsDapperProject.Domain.Exceptions.Brand;

public class BrandNotFoundException(int id) 
    : EntityNotFoundException("Бренд", id)
{
}
