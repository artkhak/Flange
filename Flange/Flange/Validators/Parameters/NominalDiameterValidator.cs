namespace Flange.Validators.Parameters
{
    using System;

    /// <summary>
    /// Валидатор диаметра подъема.
    /// </summary>
    public class NominalDiameterValidator : IValidator<object>
    {
        /// <summary>
        /// Диаметр центрального отверстия.
        /// </summary>
        private readonly Parameter _centralHoleDiameter;

        /// <summary>
        /// Номинальный диаметр резьбы.
        /// </summary>
        private readonly Parameter _nominalDiameter;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="nominalDiameter">Номинальный диаметр резьбы.</param>
        /// <param name="centralHoleDiameter">Диаметр центрального отверстия.</param>
        public NominalDiameterValidator(Parameter nominalDiameter, Parameter centralHoleDiameter)
        {
            _nominalDiameter = nominalDiameter ?? throw new ArgumentNullException(nameof(nominalDiameter));
            _centralHoleDiameter = centralHoleDiameter ?? throw new ArgumentNullException(nameof(centralHoleDiameter));
        }

        /// <summary>
        /// Проверяет значение.
        /// </summary>
        /// <param name="value">Значение (не используется).</param>
        /// <returns>Ошибка.</returns>
        public string Validate(object value)
        {
            var nominalDiameter = _nominalDiameter.Value;

            if (Math.Abs(nominalDiameter) < double.Epsilon)
                return null;

            var centralHoleDiameter = _centralHoleDiameter.Value;

            return nominalDiameter <= centralHoleDiameter
                ? $"Номинальный диаметр резьбы должен быть больше диаметра центрального отверстия ({centralHoleDiameter})."
                : null;
        }
    }
}