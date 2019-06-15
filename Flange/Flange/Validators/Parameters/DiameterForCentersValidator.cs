namespace Flange.Validators.Parameters
{
    using System;

    /// <summary>
    /// Валидатор диаметра, на котором будут располагаться центры отверстий.
    /// </summary>
    public class DiameterForCentersValidator : IValidator<object>
    {
        /// <summary>
        /// Диаметр отверстий.
        /// </summary>
        private readonly Parameter _boreDiameter;

        /// <summary>
        /// Диаметр центрального отверстия.
        /// </summary>
        private readonly Parameter _centralHoleDiameter;

        /// <summary>
        /// Диаметр, на котором будут располагаться центры отверстий.
        /// </summary>
        private readonly Parameter _diameterForCenters;

        /// <summary>
        /// Диаметр подъема.
        /// </summary>
        private readonly Parameter _liftDiameter;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="diameterForCenters">Диаметр, на котором будут располагаться центры отверстий.</param>
        /// <param name="liftDiameter">Диаметр подъема.</param>
        /// <param name="centralHoleDiameter">Диаметр центрального отверстия.</param>
        /// <param name="boreDiameter">Диаметр отверстий.</param>
        public DiameterForCentersValidator(Parameter diameterForCenters, Parameter liftDiameter,
            Parameter centralHoleDiameter, Parameter boreDiameter)
        {
            _diameterForCenters = diameterForCenters ?? throw new ArgumentNullException(nameof(diameterForCenters));
            _liftDiameter = liftDiameter ?? throw new ArgumentNullException(nameof(liftDiameter));
            _centralHoleDiameter = centralHoleDiameter ?? throw new ArgumentNullException(nameof(centralHoleDiameter));
            _boreDiameter = boreDiameter ?? throw new ArgumentNullException(nameof(boreDiameter));
        }

        /// <summary>
        /// Проверяет значение.
        /// </summary>
        /// <param name="value">Значение (не используется).</param>
        /// <returns>Ошибка.</returns>
        public string Validate(object value)
        {
            var diameterForCenters = _diameterForCenters.Value;
            var liftDiameter = _liftDiameter.Value;
            var centralHoleDiameter = _centralHoleDiameter.Value;
            var boreDiameter = _boreDiameter.Value;

            var maxIncomingDiameter = liftDiameter > 0
                ? liftDiameter
                : centralHoleDiameter;

            var minDiameterForCenters = maxIncomingDiameter + boreDiameter;

            if (diameterForCenters > minDiameterForCenters)
                return null;

            var errorString = "Диаметр, на котором лежат центры отверстий, должен быть больше суммы ";

            var errorStringEnd = liftDiameter > 0
                ? "диаметра подъема"
                : "диаметра центрального отверстия";

            errorString += errorStringEnd + $" и диаметра отверстия ({minDiameterForCenters}).";

            return errorString;
        }
    }
}