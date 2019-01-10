using System.Collections.Generic;

namespace Flange.Model.Validators
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
        /// <returns>Список ошибок.</returns>
        IEnumerable<string> Validate(T value);
    }
}