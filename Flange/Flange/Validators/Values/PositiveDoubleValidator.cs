namespace Flange.Validators.Values
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
        public string Validate(double value)
        {
            return value <= 0 ? "Значение должно быть больше 0" : null;
        }
    }
}