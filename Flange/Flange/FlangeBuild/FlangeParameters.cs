using System;
using System.Collections.Generic;
using System.Linq;
using Flange.Validators;
using Flange.Validators.Parameters;

namespace Flange.FlangeBuild
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
            var baseDiameter = new Parameter(FlangeParameterNames.BaseDiameter, FlangeParameterValidators.BaseDiameter);
            var baseHeight = new Parameter(FlangeParameterNames.BaseHeight, FlangeParameterValidators.BaseHeight);
            var boreDiameter = new Parameter(FlangeParameterNames.BoreDiameter, FlangeParameterValidators.BoreDiameter);
            var centralHoleDiameter = new Parameter(FlangeParameterNames.CentralHoleDiameter,
                FlangeParameterValidators.CentralHoleDiameter);
            var diameterForCenters = new Parameter(FlangeParameterNames.DiameterForCenters,
                FlangeParameterValidators.DiameterForCenters);
            var liftDiameter = new Parameter(FlangeParameterNames.LiftDiameter, FlangeParameterValidators.LiftDiameter);
            var liftHeight = new Parameter(FlangeParameterNames.LiftHeight, FlangeParameterValidators.LiftHeight);
            var numberOfBore = new Parameter(FlangeParameterNames.NumberOfBore, FlangeParameterValidators.NumberOfBore,
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