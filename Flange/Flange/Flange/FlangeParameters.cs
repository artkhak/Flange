using System;
using System.Collections.Generic;
using System.Linq;
using Flange.Model.Validators;

namespace Flange.Model.Flange
{
    /// <summary>
    /// Параметры фланца.
    /// </summary>
    public class FlangeParameters
    {
        /// <summary>
        /// Валидатор.
        /// </summary>
        private readonly IValidator<FlangeParameters> _validator;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="validator">Валидатор.</param>
        public FlangeParameters(IValidator<FlangeParameters> validator)
        {
            _validator = validator;
            Parameters = new List<Parameter>
            {
                new Parameter(FlangeParameterNames.BaseDiameter, FlangeParameterValidators.BaseDiameter),
                new Parameter(FlangeParameterNames.BaseHeight, FlangeParameterValidators.BaseHeight),
                new Parameter(FlangeParameterNames.BoreDiameter, FlangeParameterValidators.BoreDiameter),
                new Parameter(FlangeParameterNames.CentralHoleDiameter, FlangeParameterValidators.CentralHoleDiameter),
                new Parameter(FlangeParameterNames.DiameterForCenters, FlangeParameterValidators.DiameterForCenters),
                new Parameter(FlangeParameterNames.LiftDiameter, FlangeParameterValidators.LiftDiameter),
                new Parameter(FlangeParameterNames.LiftHeight, FlangeParameterValidators.LiftHeight),
                new Parameter(FlangeParameterNames.NumberOfBore, FlangeParameterValidators.NumberOfBore)
            };
        }

        /// <summary>
        /// Параметры.
        /// </summary>
        public List<Parameter> Parameters { get; }

        /// <summary>
        /// Список ошибок.
        /// </summary>
        public List<string> Errors => _validator.Validate(this).ToList();

        /// <summary>
        /// Индексатор для получения значения свойств.
        /// </summary>
        /// <param name="parameterName">Название параметра.</param>
        public double this[string parameterName] => Parameters.FirstOrDefault(p => p.Name == parameterName)?.Value ??
                                                    throw new ArgumentException($"Параметр {parameterName} не найден.");
    }
}