using System.Windows;
using Flange.Model;
using Flange.Model.Flange;
using Flange.Model.Validators;
using Flange.ViewModels;

namespace Flange
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
            DataContext = new FlangeParametersVM(new FlangeParameters(new FlangeParametersValidator()));
            InitializeComponent();
        }
    }
}