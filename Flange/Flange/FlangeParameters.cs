using System;
using System.Collections.Generic;
using System.Linq;
using Flange.Validators;
using Flange.Validators.Parameters;
using Flange.Validators.Values;

namespace Flange
{
    /// <summary>
    /// Параметры фланца.
    /// </summary>
    public class FlangeParameters
    {
        /// <summary>
        /// Валидатор.
        /// </summary>
        private readonly List<IValidator<object>> _validators;

        /// <summary>
        /// Конструктор.
        /// </summary>
        public FlangeParameters()
        {
            var baseDiameter = new Parameter(FlangeParameterNames.BaseDiameter, new PositiveDoubleValidator());
            var baseHeight = new Parameter(FlangeParameterNames.BaseHeight, new PositiveDoubleValidator());
            var boreDiameter = new Parameter(FlangeParameterNames.BoreDiameter, new PositiveDoubleValidator());
            var centralHoleDiameter =
                new Parameter(FlangeParameterNames.CentralHoleDiameter, new PositiveDoubleValidator());
            var diameterForCenters =
                new Parameter(FlangeParameterNames.DiameterForCenters, new PositiveDoubleValidator());
            var liftDiameter = new Parameter(FlangeParameterNames.LiftDiameter, new NotNegativeDoubleValidator());
            var liftHeight = new Parameter(FlangeParameterNames.LiftHeight, new NotNegativeDoubleValidator());
            var numberOfBore = new Parameter(FlangeParameterNames.NumberOfBore, new PositiveDoubleValidator(),
                new List<double> {5, 6, 8, 10});

            Parameters = new List<Parameter>
            {
                baseDiameter,
                baseHeight,
                boreDiameter,
                centralHoleDiameter,
                diameterForCenters,
                liftDiameter,
                liftHeight,
                numberOfBore
            };

            _validators = new List<IValidator<object>>
            {
                new BaseDiameterValidator(baseDiameter, diameterForCenters, boreDiameter),
                new DiameterForCentersValidator(diameterForCenters, liftDiameter, centralHoleDiameter, boreDiameter),
                new LiftDiameterValidator(liftDiameter, liftHeight, centralHoleDiameter),
                new LiftHeightValidator(liftHeight, liftDiameter, centralHoleDiameter)
            };
        }

        /// <summary>
        /// Параметры.
        /// </summary>
        public List<Parameter> Parameters { get; }

        /// <summary>
        /// Список ошибок.
        /// </summary>
        public List<string> Errors => _validators.Select(validator => validator.Validate(null))
            .Where(error => !string.IsNullOrWhiteSpace(error))
            .ToList();

        /// <summary>
        /// Индексатор для получения значения свойств.
        /// </summary>
        /// <param name="parameterName">Название параметра.</param>
        public double this[string parameterName] => Parameters.FirstOrDefault(p => p.Name == parameterName)?.Value ??
                                                    throw new ArgumentException($"Параметр {parameterName} не найден.");
    }
}