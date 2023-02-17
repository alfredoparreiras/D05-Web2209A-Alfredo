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
            // Set DataContext to be the view model
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