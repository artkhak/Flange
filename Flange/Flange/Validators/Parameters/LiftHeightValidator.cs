namespace Flange.Validators.Parameters
{
    using System;

    /// <summary>
    /// Валидатор высоты подъема.
    /// </summary>
    public class LiftHeightValidator : IValidator<object>
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
        /// Конструктор.
        /// </summary>
        /// <param name="liftHeight">Высота подъема.</param>
        /// <param name="liftDiameter">Диаметр подъема.</param>
        /// <param name="centralHoleDiameter">Диаметр центрального отверстия.</param>
        public LiftHeightValidator(Parameter liftHeight, Parameter liftDiameter, Parameter centralHoleDiameter)
        {
            _liftHeight = liftHeight ?? throw new ArgumentNullException(nameof(liftHeight));
            _liftDiameter = liftDiameter ?? throw new ArgumentNullException(nameof(liftDiameter));
            _centralHoleDiameter = centralHoleDiameter ?? throw new ArgumentNullException(nameof(centralHoleDiameter));
        }

        /// <summary>
        /// Проверяет значение.
        /// </summary>
        /// <param name="value">Значение (не используется).</param>
        /// <returns>Ошибка.</returns>
        public string Validate(object value)
        {
            var liftHeight = _liftHeight.Value;
            var liftDiameter = _liftDiameter.Value;

            if (Math.Abs(liftHeight) < double.Epsilon && Math.Abs(liftDiameter) < double.Epsilon)
                return null;

            if (liftDiameter > 0 && Math.Abs(liftHeight) < double.Epsilon)
                return "Высота подъема должна быть задана, если задан диаметр подъема.";

            var centralHoleDiameter = _centralHoleDiameter.Value;

            var maxLiftHeight = (liftDiameter - centralHoleDiameter) / 2;

            return liftHeight > maxLiftHeight
                ? $"Высота подъема должна быть не больше разницы радиусов диаметров подъема и центрального отверстия.({maxLiftHeight})."
                : null;
        }
    }
}