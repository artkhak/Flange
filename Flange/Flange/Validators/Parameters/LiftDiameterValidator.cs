using System;

namespace Flange.Validators.Parameters
{
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
        /// Конструктор.
        /// </summary>
        /// <param name="liftDiameter">Диаметр подъема.</param>
        /// <param name="liftHeight">Высота подъема.</param>
        /// <param name="centralHoleDiameter">Диаметр центрального отверстия.</param>
        public LiftDiameterValidator(Parameter liftDiameter, Parameter liftHeight, Parameter centralHoleDiameter)
        {
            _liftDiameter = liftDiameter;
            _liftHeight = liftHeight;
            _centralHoleDiameter = centralHoleDiameter;
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

            if (liftHeight > 0 && Math.Abs(liftDiameter) < double.Epsilon)
                return "Диаметр подъема должен быть задан, если задана высота подъема.";

            var centralHoleDiameter = _centralHoleDiameter.Value;

            return liftDiameter <= centralHoleDiameter
                ? $"Диаметр подъма должен быть больше диаметра центрального отверстия ({centralHoleDiameter})."
                : null;
        }
    }
}