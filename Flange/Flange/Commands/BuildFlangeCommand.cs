using System;
using Flange.Commands.BaseCommands;
using Flange.ViewModels;

namespace Flange.Commands
{
    /// <summary>
    /// Команда построения фланца.
    /// </summary>
    public class BuildFlangeCommand : CommandBaseWithTypedParameter<FlangeParametersVM>
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        public BuildFlangeCommand() : base("Построение модели")
        {
        }

        /// <summary>
        /// Проверяет возможность выполнения команды.
        /// </summary>
        /// <param name="flangeParametersVM">Вью-модеь параметров фланца.</param>
        /// <returns>Указывает на возможность выполнения команды.</returns>
        protected override bool CanExecute(FlangeParametersVM flangeParametersVM)
        {
            return !flangeParametersVM.HasErrors;
        }

        /// <summary>
        /// Выполняет команду.
        /// </summary>
        /// <param name="flangeParametersVM">Вью-модеь параметров фланца.</param>
        protected override void Execute(FlangeParametersVM flangeParametersVM)
        {
            throw new NotImplementedException();
        }
    }
}