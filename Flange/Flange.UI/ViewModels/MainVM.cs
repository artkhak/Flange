using System.Windows.Input;

using Flange.UI.Commands;

namespace Flange.UI.ViewModels
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
            SetDefaultValuesCommand = new SetDefaultValuesCommand();
        }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="flangeParametersVM">Вью-модель для параметров фланца.</param>
        public MainVM(FlangeParametersVM flangeParametersVM) : this()
        {
            FlangeParametersVM = flangeParametersVM;
        }

        /// <summary>
        /// Вью-модель для параметров фланца.
        /// </summary>
        public FlangeParametersVM FlangeParametersVM { get; }

        /// <summary>
        /// Команда запуска КОМПАС-3D.
        /// </summary>
        public ICommand StartKompasCommand { get; }

        /// <summary>
        /// Команда построения фланца.
        /// </summary>
        public ICommand BuildFlangeCommand { get; }

        /// <summary>
        /// Комманда очистки значений параметров фланца.
        /// </summary>
        public ICommand ClearFlangeParameterValuesCommand { get; }

        /// <summary>
        /// Команда заполнения значениями по умолчанию.
        /// </summary>
        public ICommand SetDefaultValuesCommand { get; set; }
    }
}