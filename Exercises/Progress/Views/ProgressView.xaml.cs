using Chevalier.Utility.Commands;
using Progress.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Progress.Views
{
    public partial class ProgressView : UserControl
    {
        // TODO: Bind view components to view model properties:
        // Progress bar value
        // Speed slider value
        // Speed label text
        // Button commands
        // Message label text

        public ProgressView()
        {
            InitializeComponent();

            // TODO
            // Create new ProgressViewModel
            // Add event handler method OnTaskFinished and add it to the view model's TaskFinished event
            // Add event handler method OnCommandFailed and add it to the view model's CommandFailed event
            // Set DataContext to be the view model ok


            ProgressViewModel viewModel = new ProgressViewModel();
            viewModel.TaskFinished += OnTaskFinished;
            // TODO
            viewModel.CommandFailed += OnCommandFailed;
            DataContext = viewModel;
        }

        private void OnCommandFailed(string message)
        {

            MessageBox.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void OnTaskFinished()
        {
            MessageBox.Show("Task Finished Successfully", "Finished", MessageBoxButton.OK,MessageBoxImage.Information);

        }

        // TODO: OnTaskFinished event handler method
        // Display message box with OK button and Information image
        // Message = "Task finished successfully!"
        // Title = "Task finished"


        // TODO: OnCommandFailed event handler method
        // Display message box with OK button and Warning image
        // Message = error message passed by view model
        // Title = "Error"
     
    }
}