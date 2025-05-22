namespace CarsDapperProject.Domain.Exceptions;

/// <summary>
/// Формирует сообщение исключения в формате:<br>
/// <paramref name="entityName"/> с id = <paramref name="id"/> не найден.</br>
/// </summary>
/// <param name="entityName">Название сущности.</param>
/// <param name="id">ID сущности.</param>
public abstract class EntityNotFoundException(string entityName, int id) 
    : Exception($"{entityName} с id = {id} не найден.")
{
}
