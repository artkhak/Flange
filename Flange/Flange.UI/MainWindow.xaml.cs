namespace Flange.UI
{
    using System.Windows;

    using Flange.UI.ViewModels;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        public MainWindow()
        {
            DataContext = new MainVM(new FlangeParametersVM(new FlangeParameters()));
            InitializeComponent();
        }
    }
}