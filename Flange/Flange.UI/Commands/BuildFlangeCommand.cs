namespace Flange.UI.Commands
{
    using System.Linq;
    using System.Text;

    using Flange.Kompas;
    using Flange.UI.Commands.BaseCommands;

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
            return flangeParameters.Parameters.All(p => string.IsNullOrWhiteSpace(p.Error));
        }

        /// <summary>
        /// Выполняет команду.
        /// </summary>
        /// <param name="flangeParameters">Параметры фланца.</param>
        protected override void Execute(FlangeParameters flangeParameters)
        {
            if (CheckErrors(flangeParameters))
                return;

            var kompas = KompasApp.GetActive() ?? KompasApp.Start();
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

            var errorStringBuilder = new StringBuilder();
            flangeParameters.Errors.ForEach(er => errorStringBuilder.AppendLine($"{er}\n"));
            errorStringBuilder.Remove(errorStringBuilder.Length - 1, 1);

            MessageViewer.Error("Построение модели", errorStringBuilder.ToString());

            return true;
        }
    }
}