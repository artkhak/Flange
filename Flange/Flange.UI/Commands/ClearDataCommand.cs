namespace Flange.UI.Commands
{
    using System.Globalization;
    using System.Linq;

    using Flange.UI.Commands.BaseCommands;
    using Flange.UI.ViewModels;

    /// <summary>
    /// Комманда очистки значений параметров фланца.
    /// </summary>
    public class ClearFlangeParameterValuesCommand : CommandBaseWithTypedParameter<FlangeParametersVM>
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        public ClearFlangeParameterValuesCommand() : base("Очистка значений параметров фланца")
        {
        }

        protected override bool CanExecute(FlangeParametersVM flangeParametersVM)
        {
            foreach (var parameter in flangeParametersVM.ParameterVMs)
                if (parameter.PossibleValues == null)
                {
                    if (!string.IsNullOrWhiteSpace(parameter.DisplayedValue))
                        return true;
                }
                else if (parameter.DisplayedValue != parameter.PossibleValues?.First())
                {
                    return true;
                }

            return false;
        }

        /// <summary>
        /// Вызывает выполнение команды.
        /// </summary>
        /// <param name="flangeParametersVM">Вью модель параметров фланца.</param>
        protected override void Execute(FlangeParametersVM flangeParametersVM)
        {
            foreach (var parameter in flangeParametersVM.ParameterVMs)
            {
                var firstPossibleValue = parameter.PossibleValues?.First().ToString(CultureInfo.InvariantCulture);
                parameter.DisplayedValue = firstPossibleValue ?? "";
            }
        }
    }
}