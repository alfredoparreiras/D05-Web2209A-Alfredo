﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFPApplication
{
    namespace Classes
    {
        public class Student
        {
            public int Id { get; }
            public string Name { get; set; }
            public int CoursesPassed { get; private set; }
            public DateTime DateOfBirth { get; }

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
            private bool graduated;

            public Student(int id, string name, bool graduated, int coursesPassed, DateTime dateOfBirth)
            {
                Id = id;
                Name = name;
                this.graduated = graduated;
                CoursesPassed = coursesPassed;
                DateOfBirth = dateOfBirth;
            }

            public void PassCourse()
            {
                CoursesPassed++;
            }
        }
    }

}
