using EmployeeExam.Application.ViewModels;
using System.Windows.Controls;

namespace EmployeeExam.Presentation.Views
{
    public partial class EmployeeListView : UserControl
    {
        public EmployeeListView()
        {
            InitializeComponent();
            DataContext = new EmployeeListViewModel();
        }
    }
}
