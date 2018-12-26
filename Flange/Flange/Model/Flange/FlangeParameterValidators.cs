using System.Collections.Generic;
using Flange.Model.Validators;

namespace Flange.Model.Flange
{
    /// <summary>
    /// Валидаторы для параметров фланца.
    /// </summary>
    internal static class FlangeParameterValidators
    {
        /// <summary>
        /// Диаметр основания.
        /// </summary>
        public static readonly List<IValidator<double>> BaseDiameter = new List<IValidator<double>>
            {new PositiveDoubleValidator()};

        /// <summary>
        /// Высота основания.
        /// </summary>
        public static readonly List<IValidator<double>> BaseHeight = new List<IValidator<double>>
            {new PositiveDoubleValidator()};

        /// <summary>
        /// Диаметр отверстий.
        /// </summary>
        public static readonly List<IValidator<double>> BoreDiameter = new List<IValidator<double>>
            {new PositiveDoubleValidator()};

        /// <summary>
        /// Диаметр центрального отверстия.
        /// </summary>
        public static readonly List<IValidator<double>> CentralHoleDiameter = new List<IValidator<double>>
            {new PositiveDoubleValidator()};

        /// <summary>
        /// Диаметр окружности для центра отверстий.
        /// </summary>
        public static readonly List<IValidator<double>> DiameterForCenters = new List<IValidator<double>>
            {new PositiveDoubleValidator()};

        /// <summary>
        /// Диаметр подъема.
        /// </summary>
        public static readonly List<IValidator<double>> LiftDiameter = new List<IValidator<double>>
            {new PositiveDoubleValidator()};

        /// <summary>
        /// Высота подъема.
        /// </summary>
        public static readonly List<IValidator<double>> LiftHeight = new List<IValidator<double>>
            {new PositiveDoubleValidator()};

        /// <summary>
        /// Количество отверстий.
        /// </summary>
        public static readonly List<IValidator<double>> NumberOfBore = new List<IValidator<double>>
            {new PositiveDoubleValidator()};
    }
}