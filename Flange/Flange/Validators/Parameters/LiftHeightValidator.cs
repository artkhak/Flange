namespace Flange.Validators.Parameters
{
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
            _liftHeight = liftHeight;
            _liftDiameter = liftDiameter;
            _centralHoleDiameter = centralHoleDiameter;
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
            var centralHoleDiameter = _centralHoleDiameter.Value;

            var minLiftHeight = (liftDiameter - centralHoleDiameter) / 2;

            return liftHeight > minLiftHeight
                ? $"Высота подъма должна быть не больше разницы радиусов диаметров подъема и центрального отверстия.({minLiftHeight})."
                : null;
        }
    }
}