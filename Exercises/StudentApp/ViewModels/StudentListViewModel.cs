using System;
using System.Collections.ObjectModel;
using Chevalier.Utility.Commands;
using Chevalier.Utility.ViewModels;
using WpfDemo;

namespace StudentApp.ViewModels
{
    public class StudentListViewModel : ViewModel
    {
        public ObservableCollection<Student> Students { get; }
        public Student SelectedStudent { get; set; }
        public string Name { get; set; }
        public DelegateCommand ChangeNameCommand { get; }
        public DelegateCommand PassCourseCommand { get; }

        public StudentListViewModel()
        {
            Students = new ObservableCollection<Student>
            {
                new Student(id: 1, name: "Anna", graduated: false, coursesPassed: 2, dateOfBirth: new DateTime(2000, 1, 1)),
                new Student(id: 2, name: "Catherine", graduated: false, coursesPassed: 4, dateOfBirth: new DateTime(2000, 12, 1)),
                new Student(id: 3, name: "Emily", graduated: true, coursesPassed: 10, dateOfBirth: new DateTime(2005, 6, 1))
            };

            SelectedStudent = null;
            Name = null;

            ChangeNameCommand = new DelegateCommand(ChangeName);
            PassCourseCommand = new DelegateCommand(PassCourse);
        }

        private void ChangeName(object _)
        {
            if (SelectedStudent is not null)
            {
                SelectedStudent.Name = Name;

                // Clear text box
                Name = string.Empty;
                NotifyPropertyChanged(nameof(Name));

                // Deselect data grid
                SelectedStudent = null;
                NotifyPropertyChanged(nameof(SelectedStudent));
            }
        }

        private void PassCourse(object _)
        {
            if (SelectedStudent is not null)
            {
                SelectedStudent.PassCourse();
            }
        }
    }
}
