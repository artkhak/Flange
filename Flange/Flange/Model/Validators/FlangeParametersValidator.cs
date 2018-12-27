using System.Collections.Generic;
using Flange.Model.Flange;

namespace Flange.Model.Validators
{
    /// <summary>
    /// Валидатор параметров фланца.
    /// </summary>
    public class FlangeParametersValidator : IValidator<FlangeParameters>
    {
        /// <summary>
        /// Проверяет значение.
        /// </summary>
        /// <param name="parameters">Параметры.</param>
        /// <returns>Список ошибок.</returns>
        public IEnumerable<string> Validate(FlangeParameters parameters)
        {
            var errors = new List<string>();

            var diameterForCenters = parameters[FlangeParameterNames.DiameterForCenters];
            var baseDiameter = parameters[FlangeParameterNames.BaseDiameter];
            var centralHoleDiameter = parameters[FlangeParameterNames.CentralHoleDiameter];
            var boreDiameter = parameters[FlangeParameterNames.BoreDiameter];
            var liftDiameter = parameters[FlangeParameterNames.LiftDiameter];
            var liftHeight = parameters[FlangeParameterNames.LiftHeight];

            if (liftDiameter > 0 && diameterForCenters <= liftDiameter + boreDiameter)
                errors.Add(GetStringMoreThanSum(FlangeParameterNames.DiameterForCenters,
                    FlangeParameterNames.BoreDiameter, FlangeParameterNames.LiftDiameter));
            else if (diameterForCenters <= centralHoleDiameter + boreDiameter)
                errors.Add(GetStringMoreThanSum(FlangeParameterNames.DiameterForCenters,
                    FlangeParameterNames.BoreDiameter, FlangeParameterNames.CentralHoleDiameter));

            if (diameterForCenters >= baseDiameter - boreDiameter)
                errors.Add(GetStringLessThanDifference(FlangeParameterNames.DiameterForCenters,
                    FlangeParameterNames.BaseDiameter, FlangeParameterNames.BoreDiameter));

            if (liftDiameter > 0 && liftHeight == 0)
                errors.Add(GetStringRequired(FlangeParameterNames.LiftHeight));
            else if (liftDiameter <= centralHoleDiameter)
                errors.Add(GetStringLessThan(FlangeParameterNames.CentralHoleDiameter,
                    FlangeParameterNames.LiftDiameter));

            if (liftHeight > 0 && liftDiameter == 0)
                errors.Add(GetStringRequired(FlangeParameterNames.LiftDiameter));
            else if (liftHeight > (liftDiameter - centralHoleDiameter) / 2)
                errors.Add(GetStringLessThan(FlangeParameterNames.LiftHeight,
                    $"полуразность {FlangeParameterNames.LiftDiameter} и {FlangeParameterNames.CentralHoleDiameter}"));

            if (centralHoleDiameter >= baseDiameter)
                errors.Add(GetStringLessThan(FlangeParameterNames.CentralHoleDiameter,
                    FlangeParameterNames.BaseDiameter));

            if (boreDiameter >= baseDiameter - centralHoleDiameter)
                errors.Add(GetStringLessThanDifference(FlangeParameterNames.BoreDiameter,
                    FlangeParameterNames.BaseDiameter, FlangeParameterNames.CentralHoleDiameter));

            return errors;
        }

        private static string GetStringLessThan(string parameterName, string lessThanName)
        {
            return $"{parameterName} должен быть меньше, чем {lessThanName}";
        }

        private static string GetStringLessThanDifference(string parameterName, string minuendName,
            string subtrahendName)
        {
            return $"{parameterName} должен быть меньше, чем разность {minuendName} и {subtrahendName}";
        }

        private static string GetStringMoreThanSum(string parameterName, string firstAddendName,
            string secondAddendName)
        {
            return $"{parameterName} должен быть больше, чем сумма {firstAddendName} и {secondAddendName}";
        }

        private static string GetStringRequired(string parameterName)
        {
            return $"Параметр {parameterName} должен быть задан";
        }
    }
}