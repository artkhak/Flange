using Flange.Commands;

namespace Flange.ViewModels
{
    /// <summary>
    /// Основная вью-модель.
    /// </summary>
    public class MainVM
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        public MainVM()
        {
            StartKompasCommand = new StartKompasCommand();
            BuildFlangeCommand = new BuildFlangeCommand();
            ClearFlangeParameterValuesCommand = new ClearFlangeParameterValuesCommand();
        }

        /// <summary>
        /// Команда запуска КОМПАС-3D.
        /// </summary>
        public StartKompasCommand StartKompasCommand { get; }

        /// <summary>
        /// Команда построения фланца.
        /// </summary>
        public BuildFlangeCommand BuildFlangeCommand { get; }

        /// <summary>
        /// Комманда очистки значений параметров фланца.
        /// </summary>
        public ClearFlangeParameterValuesCommand ClearFlangeParameterValuesCommand { get; }
    }
}