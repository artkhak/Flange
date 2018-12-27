using System.Collections.Generic;

namespace Flange.Model.Validators
{
    /// <summary>
    /// Проверяет, что значение больше положительно.
    /// </summary>
    public class PositiveDoubleValidator : IValidator<double>
    {
        /// <summary>
        /// Проверяет значение.
        /// </summary>
        /// <param name="value">Значение.</param>
        /// <returns>Список ошибок.</returns>
        public IEnumerable<string> Validate(double value)
        {
            return value <= 0 ? new List<string> {"Значение должно быть больше 0"} : new List<string>();
        }
    }
}