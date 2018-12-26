using System;
using Flange.Commands.BaseCommands;
using Flange.ViewModels;

namespace Flange.Commands
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
        }
    }
}