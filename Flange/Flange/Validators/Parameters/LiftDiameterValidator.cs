namespace Flange.Validators.Parameters
{
    using System;

    /// <summary>
    /// Валидатор диаметра подъема.
    /// </summary>
    public class LiftDiameterValidator : IValidator<object>
    {
        /// <summary>
        /// Диаметр центрального отверстия.
        /// </summary>
        private readonly Parameter _centralHoleDiameter;

        /// <summary>
        /// Диаметр подъема.
        /// </summary>
        private readonly Parameter _liftDiameter;

        /// <summary>
        /// Высота подъема.
        /// </summary>
        private readonly Parameter _liftHeight;

        /// <summary>
        /// Номинальный диаметр резьбы.
        /// </summary>
        private readonly Parameter _nominalDiameter;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="liftDiameter">Диаметр подъема.</param>
        /// <param name="liftHeight">Высота подъема.</param>
        /// <param name="centralHoleDiameter">Диаметр центрального отверстия.</param>
        /// <param name="nominalDiameter">Номинальный диаметр резьбы.</param>
        public LiftDiameterValidator(Parameter liftDiameter, Parameter liftHeight, Parameter centralHoleDiameter,
            Parameter nominalDiameter)
        {
            _liftDiameter = liftDiameter ?? throw new ArgumentNullException(nameof(liftDiameter));
            _liftHeight = liftHeight ?? throw new ArgumentNullException(nameof(liftHeight));
            _centralHoleDiameter = centralHoleDiameter ?? throw new ArgumentNullException(nameof(centralHoleDiameter));
            _nominalDiameter = nominalDiameter ?? throw new ArgumentNullException(nameof(nominalDiameter));
        }

        /// <summary>
        /// Проверяет значение.
        /// </summary>
        /// <param name="value">Значение (не используется).</param>
        /// <returns>Ошибка.</returns>
        public string Validate(object value)
        {
            var liftDiameter = _liftDiameter.Value;
            var liftHeight = _liftHeight.Value;

            if (Math.Abs(liftHeight) < double.Epsilon && Math.Abs(liftDiameter) < double.Epsilon)
                return null;

            if (liftHeight > 0 && Math.Abs(liftDiameter) < double.Epsilon)
                return "Диаметр подъема должен быть задан, если задана высота подъема.";

            var nominalDiameter = _nominalDiameter.Value;
            var centralHoleDiameter = _centralHoleDiameter.Value;

            var minLiftDiameter = nominalDiameter > 0
                ? nominalDiameter + 2 * liftHeight
                : centralHoleDiameter;

            var errorMessage = "Диаметр подъема должен быть больше ";
            errorMessage += nominalDiameter > 0
                ? $"суммы номинального диаметра резьбы и удвоенной высоты подъема ({nominalDiameter})."
                : $"диаметра центрального отверстия ({centralHoleDiameter}).";

            return liftDiameter <= minLiftDiameter
                ? errorMessage
                : null;
        }
    }
}