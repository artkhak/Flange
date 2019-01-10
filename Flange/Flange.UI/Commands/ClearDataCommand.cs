using Flange.Model.Flange;
using Flange.UI.Commands.BaseCommands;

namespace Flange.UI.Commands
{
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

        /// <summary>
        /// Вызывает выполнение команды.
        /// </summary>
        /// <param name="flangeParametersVM">Вью модель параметров фланца.</param>
        protected override void Execute(FlangeParametersVM flangeParametersVM)
        {
            flangeParametersVM.ParameterVMs.ForEach(p => p.DisplayedValue = "");

            var numberOfBore =
                flangeParametersVM.ParameterVMs.First(p => p.Name == FlangeParameterNames.NumberOfBore);

            numberOfBore.DisplayedValue = "5";
        }
    }
}