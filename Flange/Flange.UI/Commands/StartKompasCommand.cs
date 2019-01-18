using Flange.Kompas;
using Flange.UI.Commands.BaseCommands;

namespace Flange.UI.Commands
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