using System.Windows;
using Flange.FlangeBuild;
using Flange.UI.ViewModels;

namespace Flange.UI
{
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