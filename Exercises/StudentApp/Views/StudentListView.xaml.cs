using System.Windows.Controls;
using StudentApp.ViewModels;

namespace StudentApp.Views
{
    public partial class StudentListView : UserControl
    {
        public StudentListView()
        {
            InitializeComponent();
            DataContext = new StudentListViewModel();
        }
    }
}
