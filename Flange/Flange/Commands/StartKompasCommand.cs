using Flange.Commands.BaseCommands;
using Flange.Model;
using Flange.Model.Kompas;

namespace Flange.Commands
{
    /// <summary>
    /// Команда запуска КОМПАС-3D.
    /// </summary>
    public class StartKompasCommand : CommandBaseWithoutParameter
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        public StartKompasCommand() : base("Запуск КОМПАС-3D")
        {
        }

        /// <summary>
        /// Вызывает выполнение команды.
        /// </summary>
        protected override void Execute()
        {
            KompasAppManager.Start();
        }
    }
}