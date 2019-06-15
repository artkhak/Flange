namespace Flange.Validators.Values
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
        public string Validate(double value)
        {
            return value < 0 ? "Значение должно быть не отрицательным" : null;
        }
    }
}