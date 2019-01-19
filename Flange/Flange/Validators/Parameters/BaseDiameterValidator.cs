using System;

namespace Flange.Validators.Parameters
{
    /// <summary>
    /// Валидатор диаметра основания.
    /// </summary>
    public class BaseDiameterValidator : IValidator<object>
    {
        /// <summary>
        /// Диаметр основания.
        /// </summary>
        private readonly Parameter _baseDiameter;

        /// <summary>
        /// Диаметр отверстий.
        /// </summary>
        private readonly Parameter _boreDiameter;

        /// <summary>
        /// Диаметр, на котором будут располагаться центры отверстий.
        /// </summary>
        private readonly Parameter _diameterForCenters;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="baseDiameter">Диаметр основания.</param>
        /// <param name="diameterForCenters">Диаметр, на котором будут располагаться центры отверстий.</param>
        /// <param name="boreDiameter">Диаметр отверстий.</param>
        public BaseDiameterValidator(Parameter baseDiameter, Parameter diameterForCenters, Parameter boreDiameter)
        {
            _baseDiameter = baseDiameter ?? throw new ArgumentNullException(nameof(baseDiameter));
            _diameterForCenters = diameterForCenters ?? throw new ArgumentNullException(nameof(diameterForCenters));
            _boreDiameter = boreDiameter ?? throw new ArgumentNullException(nameof(boreDiameter));
        }

        /// <summary>
        /// Проверяет значение.
        /// </summary>
        /// <param name="value">Значение (не используется).</param>
        /// <returns>Ошибка.</returns>
        public string Validate(object value)
        {
            var baseDiameter = _baseDiameter.Value;
            var diameterForCenters = _diameterForCenters.Value;
            var boreDiameter = _boreDiameter.Value;

            var minBaseDiameter = diameterForCenters + boreDiameter;

            return baseDiameter <= minBaseDiameter
                ? $"Диаметр основания должен быть больше суммы диаметра, на котором будут распологаться отверстия, и диаметра отверстия ({minBaseDiameter})."
                : null;
        }
    }
}