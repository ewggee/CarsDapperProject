namespace CarsDapperProject.Application.Exceptions.Brand;

public class BrandNotFoundException : EntityNotFoundException
{
    public BrandNotFoundException(int id) : base($"Бренд с id = {id} не найден.") { }
}
