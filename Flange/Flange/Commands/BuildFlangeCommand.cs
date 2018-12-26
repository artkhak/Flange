using System;
using System.Linq;
using Flange.Commands.BaseCommands;
using Flange.Model.Flange;
using Flange.ViewModels;

namespace Flange.Commands
{
    /// <summary>
    /// Команда построения фланца.
    /// </summary>
    public class BuildFlangeCommand : CommandBaseWithTypedParameter<FlangeParameters>
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
        /// <param name="flangeParameters">Параметры фланца.</param>
        /// <returns>Указывает на возможность выполнения команды.</returns>
        protected override bool CanExecute(FlangeParameters flangeParameters)
        {
            return !flangeParameters.Errors.Any() && !flangeParameters.Parameters.Any(p => p.Errors.Any());
        }

        /// <summary>
        /// Выполняет команду.
        /// </summary>
        /// <param name="flangeParameters">Параметры фланца.</param>
        protected override void Execute(FlangeParameters flangeParameters)
        {
            throw new NotImplementedException();
        }
    }
}