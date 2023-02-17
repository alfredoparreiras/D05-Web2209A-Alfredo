namespace Chapter1_2
{
    public class Company
    {
        public string Name { get; }
        public string Address { get; }
        public string PhoneNumber { get; }
        public string FaxNumber { get; }
        public string WebsiteUrl { get; }
        public Manager Manager { get; }

        public Company(string name, string address, string phoneNumber, string faxNumber, string websiteUrl, Manager manager)
        {
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            FaxNumber = faxNumber;
            WebsiteUrl = websiteUrl;
            Manager = manager;
        }

        public override string ToString()
        {
            return $"Company {Name}: Address = {Address}, Phone number = {PhoneNumber}, Fax number = {FaxNumber}, Website URL = {WebsiteUrl}, Manager = ({Manager})";
        }
    }
}
