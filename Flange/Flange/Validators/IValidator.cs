namespace Flange.Validators
{
    /// <summary>
    /// Интерфейс объекта для проверки значения.
    /// </summary>
    /// <typeparam name="T">Тип значения.</typeparam>
    public interface IValidator<in T>
    {
        /// <summary>
        /// Проверяет значение.
        /// </summary>
        /// <param name="value">Значение.</param>
        /// <returns>Ошибка.</returns>
        string Validate(T value);
    }
}