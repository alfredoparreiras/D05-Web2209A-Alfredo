using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeProgram
{
    internal class Employee
    {
        //Automatic Properties
        public int Id { get; }
        public string Name { get; set; }

        //Manual Properties
        public string NameLength
        {
            get
            {
                if (Name == null)
                    return "0";
                return Name.Length.ToString();
            }
        }

        public double Height
        {
            get
            {
                return height;
            }
            set
            {
                if (value > 0)
                {
                    height = value;
                }
                    
            }
        }

        public double HeightInFeet
        {
            get
            {
                return height * 3.28084;
            }
        }

        public decimal Income
        {
            get
            {
                return income;
            }
            private set
            {

            }
        }

        //Fields 
        private decimal income;
        private double height;

        //Constructors
        public Employee(int id, string name, double height, decimal Income) 
        {
            this.Id = id;
            this.Name = name;
            this.height = height;
            this.income = Income;
        
        }

        // Methods
        public void SetIncome(decimal Income)
        {
            this.Income = Income;
        }

    }
}
