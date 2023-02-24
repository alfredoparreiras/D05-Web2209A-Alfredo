using EmployeeExam.Application.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;

namespace EmployeeExam.Presentation.Views
{
    public partial class EmployeeListView : UserControl
    {
        public EmployeeListView()
        {
            InitializeComponent();
            var viewModel = new EmployeeListViewModel();
            viewModel.CommandFailed += OnCommandFailled;
            DataContext = viewModel;
        }

        private void OnCommandFailled(string message)
        {
            MessageBox.Show(message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
