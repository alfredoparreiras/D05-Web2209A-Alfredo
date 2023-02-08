using Passport.Menu;

namespace Passport
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var menu = new PassportMenu();
            menu.Start();
        }
    }
}