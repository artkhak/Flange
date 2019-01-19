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
        public LiftDiameterValidator(Parameter liftDiameter, Parameter liftHeight, Parameter centralHoleDiameter, Parameter nominalDiameter)
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

            if (nominalDiameter > 0)
                return liftDiameter <= nominalDiameter
                    ? $"Диаметр подъема должен быть больше номинального диаметра резьбы ({nominalDiameter})."
                    : null;

            var centralHoleDiameter = _centralHoleDiameter.Value;

            return liftDiameter <= centralHoleDiameter
                ? $"Диаметр подъема должен быть больше диаметра центрального отверстия ({centralHoleDiameter})."
                : null;
        }
    }
}