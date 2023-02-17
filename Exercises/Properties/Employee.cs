namespace Properties
{
    public class Employee
    {
        // Compile-time constant
        private const double FeetPerMeter = 3.28084;

        // Automatic properties (with compiler-defined backing field + get + set)
        public int Id { get; }
        public string Name { get; set; }
        public decimal Income { get; private set; }

        // Manual property (with programmer-defined backing field)
        public double Height
        {
            get => height;
            set
            {
                if (value >= 0)
                    height = value;
            }
        }

        // Manual properties (read-only calculated properties with no backing field)
        public int NameLength => Name != null ? Name.Length : 0;
        public double HeightInFeet => Height * FeetPerMeter;

        private double height;

        public Employee(int id, string name, double height, decimal income)
        {
            Id = id;
            Name = name;
            this.height = height;
            Income = income;
        }
    }
}
