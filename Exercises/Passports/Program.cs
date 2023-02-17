using Passports.Views;

namespace Passports
{
    internal class Program
    {
        private static void Main()
        {
            PassportMenu menu = new PassportMenu();
            menu.Start();
        }
    }
}