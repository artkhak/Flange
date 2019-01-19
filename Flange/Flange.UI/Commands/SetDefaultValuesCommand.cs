using System.Globalization;
using System.Linq;
using Flange.UI.Commands.BaseCommands;
using Flange.UI.ViewModels;

namespace Flange.UI.Commands
{
    /// <summary>
    /// Команда заполнения значениями по умолчанию.
    /// </summary>
    public class SetDefaultValuesCommand : CommandBaseWithTypedParameter<FlangeParametersVM>
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        public SetDefaultValuesCommand() : base("Заполнение значениями по умолчанию")
        {
        }

        /// <summary>
        /// Вызывает выполнение команды.
        /// </summary>
        /// <param name="flangeParametersVM">Вью-модель параметров фланца.</param>
        protected override void Execute(FlangeParametersVM flangeParametersVM)
        {
            SetDisplayedValueOfFlangeParameterVMByName(flangeParametersVM, FlangeParameterNames.BaseDiameter, 30);
            SetDisplayedValueOfFlangeParameterVMByName(flangeParametersVM, FlangeParameterNames.BaseHeight, 2);
            SetDisplayedValueOfFlangeParameterVMByName(flangeParametersVM, FlangeParameterNames.BoreDiameter, 2);
            SetDisplayedValueOfFlangeParameterVMByName(flangeParametersVM, FlangeParameterNames.CentralHoleDiameter,
                13);
            SetDisplayedValueOfFlangeParameterVMByName(flangeParametersVM, FlangeParameterNames.DiameterForCenters, 24);
            SetDisplayedValueOfFlangeParameterVMByName(flangeParametersVM, FlangeParameterNames.LiftDiameter, 20);
            SetDisplayedValueOfFlangeParameterVMByName(flangeParametersVM, FlangeParameterNames.LiftHeight, 1);
            SetDisplayedValueOfFlangeParameterVMByName(flangeParametersVM, FlangeParameterNames.NumberOfBore, 8);
        }

        /// <summary>
        /// Устанавливает значение параметра фланца по имени.
        /// </summary>
        /// <param name="flangeParametersVM"></param>
        /// <param name="parameterName"></param>
        /// <param name="value"></param>
        private static void SetDisplayedValueOfFlangeParameterVMByName(FlangeParametersVM flangeParametersVM,
            string parameterName,
            double value)
        {
            var parameter = flangeParametersVM.ParameterVMs.FirstOrDefault(p => p.Name.Equals(parameterName));

            if (parameter == null)
                return;

            parameter.DisplayedValue = value.ToString(CultureInfo.CurrentCulture);
        }
    }
}