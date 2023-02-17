using System;
using Chevalier.Utility.ViewModels;

namespace WpfDemo
{
    public class Student : ViewModel
    {
        public int Id { get; }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    name = value;
                    NotifyPropertyChanged(nameof(Name));
                }
            }
        }


        public int CoursesPassed { get; private set; }
        public DateTime DateOfBirth { get; set; }

        public bool Graduated
        {
            get
            {
                return graduated;
            }
            set
            {
                if (!value || CoursesPassed >= RequiredCoursesForGraduation)
                {
                    graduated = value;
                }
            }
        }

        public int Age
        {
            get
            {
                DateTime today = DateTime.Today;
                TimeSpan duration = today - DateOfBirth;
                return (int)duration.TotalDays / 365;
            }
        }

        private const int RequiredCoursesForGraduation = 5;
        private string name;
        private bool graduated;

        public Student(int id, string name, bool graduated, int coursesPassed, DateTime dateOfBirth)
        {
            Id = id;
            this.name = name;
            this.graduated = graduated;
            CoursesPassed = coursesPassed;
            DateOfBirth = dateOfBirth;
        }

        public void PassCourse()
        {
            CoursesPassed++;
            NotifyPropertyChanged(nameof(CoursesPassed));
        }
    }
}
