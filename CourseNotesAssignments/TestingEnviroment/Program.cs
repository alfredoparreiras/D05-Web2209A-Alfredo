using System.Data;

namespace TestingEnviroment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var date = new DateTime(2020, 01, 06);
            var date2 = DateTime.UtcNow;
            var date3 = date2 - date;
            Console.WriteLine(DateTime.Today);
            Console.WriteLine(date3.Days / 365);
            if (date.CompareTo(date2) >= 0)
            {
                TimeSpan interval = date - date2;
                Console.WriteLine(interval.Days);
            }
            else
            {
                TimeSpan interval = date2 - date;
                Console.WriteLine(interval.Days);
                Console.WriteLine("Aqui");

             
            }

            //Console.WriteLine($"Current date {date} and UTC Now {date2}, try minus {date2 - date}");

        }
    }
}