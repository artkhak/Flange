using System.Linq;
using System.Text;
using Flange.Model.Flange;
using Flange.Model.Kompas;
using Flange.UI.Commands.BaseCommands;

namespace Flange.UI.Commands
{
    /// <summary>
    /// Команда построения фланца.
    /// </summary>
    public class BuildFlangeCommand : CommandBaseWithTypedParameter<FlangeParameters>
    {
        /// <summary>
        /// Угол подъема.
        /// </summary>
        private const int ChamferAngle = 45;

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
            return !flangeParameters.Parameters.Any(p => p.Errors.Any());
        }

        /// <summary>
        /// Выполняет команду.
        /// </summary>
        /// <param name="flangeParameters">Параметры фланца.</param>
        protected override void Execute(FlangeParameters flangeParameters)
        {
            if (CheckErrors(flangeParameters))
                return;

            var kompas = KompasAppManager.GetActive() ?? KompasAppManager.Start();
            var builder = new FlangeBuilder(kompas);
            builder.Build(flangeParameters);
        }

        /// <summary>
        /// Проверяет параметры на ошибки.
        /// </summary>
        /// <param name="flangeParameters">Параметры фланца.</param>
        /// <returns>Есть ли ошибки?</returns>
        private static bool CheckErrors(FlangeParameters flangeParameters)
        {
            if (!flangeParameters.Errors.Any())
                return false;

            var sb = new StringBuilder();
            flangeParameters.Errors.ForEach(er => sb.AppendLine($"{er}\n"));
            sb.Remove(sb.Length - 1, 1);

            MessageViewer.Error("Построение модели", sb.ToString());

            return true;
        }
    }
}