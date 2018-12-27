using System;

namespace Flange.Model.Flange
{
    /// <summary>
    /// Фланец.
    /// </summary>
    public class FlangeModel
    {
        /// <summary>
        /// Поле для <see cref="BaseDiameter" />.
        /// </summary>
        private double _baseDiameter;

        /// <summary>
        /// Поле для <see cref="BaseHeight" />.
        /// </summary>
        private double _baseHeight;

        /// <summary>
        /// Поле для <see cref="BoreDiameter" />.
        /// </summary>
        private double _boreDiameter;

        /// <summary>
        /// Поле для <see cref="CentralHoleDiameter" />.
        /// </summary>
        private double _centralHoleDiameter;

        /// <summary>
        /// Поле для <see cref="DiameterForCenters" />.
        /// </summary>
        private double _diameterForCenters;

        /// <summary>
        /// Поле для <see cref="LiftDiameter" />.
        /// </summary>
        private double _liftDiameter;

        /// <summary>
        /// Поле для <see cref="LiftHeight" />.
        /// </summary>
        private double _liftHeight;

        /// <summary>
        /// Поле для <see cref="NumberOfBore" />.
        /// </summary>
        private int _numberOfBore;

        /// <summary>
        /// Диаметр основания.
        /// </summary>
        public double BaseDiameter
        {
            get => _baseDiameter;
            set
            {
                ValidatePositiveNumber(value);
                _baseDiameter = value;
            }
        }

        /// <summary>
        /// Диаметр окружности, на которой будут располагаться центры отверстий.
        /// </summary>
        public double DiameterForCenters
        {
            get => _diameterForCenters;
            set
            {
                ValidatePositiveNumber(value);
                ValidateDiameterForCenter(value);
                _diameterForCenters = value;
            }
        }

        /// <summary>
        /// Диаметр центрального отверстия.
        /// </summary>
        public double CentralHoleDiameter
        {
            get => _centralHoleDiameter;
            set
            {
                ValidatePositiveNumber(value);
                _centralHoleDiameter = value;
            }
        }

        /// <summary>
        /// Диаметр подъема.
        /// </summary>
        public double LiftDiameter
        {
            get => _liftDiameter;
            set
            {
                ValidateNotNegativeValue(value);
                _liftDiameter = value;
            }
        }

        /// <summary>
        /// Высота подъема.
        /// </summary>
        public double LiftHeight
        {
            get => _liftHeight;
            set
            {
                ValidateNotNegativeValue(value);
                _liftHeight = value;
            }
        }

        /// <summary>
        /// Высота основания.
        /// </summary>
        public double BaseHeight
        {
            get => _baseHeight;
            set
            {
                ValidatePositiveNumber(value);
                _baseHeight = value;
            }
        }

        /// <summary>
        /// Диаметр отверстий.
        /// </summary>
        public double BoreDiameter
        {
            get => _boreDiameter;
            set
            {
                ValidatePositiveNumber(value);
                _boreDiameter = value;
            }
        }

        /// <summary>
        /// Количество отверстий.
        /// </summary>
        public int NumberOfBore
        {
            get => _numberOfBore;
            set
            {
                ValidatePositiveNumber(value);
                _numberOfBore = value;
            }
        }

        private void ValidateDiameterForCenter(double value)
        {
            if (LiftDiameter > 0)
            {
                if (LiftDiameter + BoreDiameter >= value)
                    throw new ArgumentException("1111111");
            }
            else
            {
                if (CentralHoleDiameter + BoreDiameter >= value)
                    throw new ArgumentException("2222222");
            }
        }

        /// <summary>
        /// Проверяет, что значение положительно.
        /// </summary>
        /// <param name="value">Значение.</param>
        private static void ValidatePositiveNumber(double value)
        {
            if (value <= 0)
                throw new ArgumentException("Значение должно быть больше 0");
        }

        /// <summary>
        /// Проверяет, что значение не отрицательно.
        /// </summary>
        /// <param name="value">Значение.</param>
        private static void ValidateNotNegativeValue(double value)
        {
            if (value < 0)
                throw new ArgumentException("Значение должно быть не меньше 0");
        }
    }
}