using Passport.Menu;

namespace Passport
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var passportMenu = new PassportMenu();
            passportMenu.Start();
        }
    }
}