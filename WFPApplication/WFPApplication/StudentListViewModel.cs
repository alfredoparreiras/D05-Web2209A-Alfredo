using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFPApplication.Classes;

namespace WFPApplication
{
    public class StudentListViewModel
    {
        public ObservableCollection<Student> Students { get; }

        public StudentListViewModel()
        {
            Students = new ObservableCollection<Student>();

            Students.Add(new Student(1, "Alfredo Parreira", false, 3, new DateTime(1990, 09, 19)));
            Students.Add(new Student(2, "Danials Bazhed", false, 5, new DateTime(2000, 10, 19)));
            Students.Add(new Student(3, "Gabriela Bazhed", false, 1, new DateTime(1997, 09, 29)));
            Students.Add(new Student(3, "Reahman :)", false, 8, new DateTime(2003, 03, 29)));
        }
    }
}
