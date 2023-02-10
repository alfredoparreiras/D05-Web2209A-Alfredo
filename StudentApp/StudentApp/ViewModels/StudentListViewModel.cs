using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDemo;

namespace StudentApp.ViewModels
{
    public class StudentListViewModel
    {
        public ObservableCollection<Student> Students { get; }

        public StudentListViewModel()
        {
            Students = new ObservableCollection<Student>();

            Students.Add(new Student(1, "Alfredo Parreira", false, 5, new DateTime(1990, 09, 19)));
            Students.Add(new Student(2, "Carolina Dias", false, 15, new DateTime(1994, 09, 22)));
            Students.Add(new Student(3, "Danials Belzad", false, 10, new DateTime(2002, 04, 25)));
        }
    }
}
