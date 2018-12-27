using System.Collections.Generic;

namespace Flange.Model.Validators
{
    /// <summary>
    /// Проверяет, что значение не отрицательно.
    /// </summary>
    public class NotNegativeDoubleValidator : IValidator<double>
    {
        /// <summary>
        /// Проверяет значение.
        /// </summary>
        /// <param name="value">Значение.</param>
        /// <returns>Список ошибок.</returns>
        public IEnumerable<string> Validate(double value)
        {
            return value < 0 ? new List<string> {"Значение должно быть не отрицательным"} : new List<string>();
        }
    }
}