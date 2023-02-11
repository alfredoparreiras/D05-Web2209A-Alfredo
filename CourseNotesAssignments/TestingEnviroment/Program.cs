using System.Data;
using System.Text;

namespace TestingEnviroment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var date = new DateTime(2020, 01, 06);
            //var date2 = DateTime.UtcNow;
            //var date3 = date2 - date;
            //Console.WriteLine(DateTime.Today);
            //Console.WriteLine(date3.Days / 365);
            //if (date.CompareTo(date2) >= 0)
            //{
            //    TimeSpan interval = date - date2;
            //    Console.WriteLine(interval.Days);
            //}
            //else
            //{
            //    TimeSpan interval = date2 - date;
            //    Console.WriteLine(interval.Days);
            //    Console.WriteLine("Aqui");
            //Console.WriteLine($"Current date {date} and UTC Now {date2}, try minus {date2 - date}");

            //StringBuilder builder = new StringBuilder();
            //Enumerable
            //   .Range(65, 26)
            //    .Select(e => ((char)e).ToString())
            //    .Concat(Enumerable.Range(97, 26).Select(e => ((char)e).ToString()))
            //    .Concat(Enumerable.Range(0, 10).Select(e => e.ToString()))
            //    .OrderBy(e => Guid.NewGuid())
            //    .Take(8)
            //    .ToList().ForEach(e => builder.Append(e));
            //string id = builder.ToString();
            //Console.WriteLine(id);

            // Console.Write("Enter a date :  ");
            // DateTime dateAdd = DateTime.Parse(Console.ReadLine());
            // Console.WriteLine(dateAdd);

            var today = DateTime.Now;
            var dateOfBirth = new DateTime(1990, 09, 19);
            var age = (today - dateOfBirth) / 366;
            Console.WriteLine(age.Days);

            string message = " Alfredo Parreira Silva";
           

        }
        
        }
    }
