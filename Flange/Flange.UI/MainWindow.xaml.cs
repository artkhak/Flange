﻿using System.Windows;
using Flange.Model.Flange;
using Flange.Model.Validators;
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
            DataContext = new MainVM(new FlangeParametersVM(new FlangeParameters(new FlangeParametersValidator())));
            InitializeComponent();
        }
    }
}