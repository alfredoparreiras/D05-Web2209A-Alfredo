namespace Chapter1_2
{
    public class Manager
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string PhoneNumber { get; }

        public Manager(string firstName, string lastName, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
        }

        public override string ToString()
        {
            return $"Manager {FirstName} {LastName}: Phone number = {PhoneNumber}";
        }
    }
}
