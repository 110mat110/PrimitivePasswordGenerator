using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator {
    class Program {
        const int maxLength = 64;

        static void Main(string[] args) {
           

            Console.WriteLine("How long should be password?");
            int length = int.Parse(Console.ReadLine());

            Console.WriteLine("\nCan be longer? Max "+ maxLength.ToString()+" chars Y/N");
            bool longer = Console.ReadKey().Key == ConsoleKey.Y;

            Console.WriteLine("\nNumbers? Y/N");
            bool numbers = Console.ReadKey().Key == ConsoleKey.Y;

            Console.WriteLine("\nSpecial characters? Y/N");
            bool specials = Console.ReadKey().Key == ConsoleKey.Y;


            while (true) {
                string pass = GeneratePassword(length, longer, numbers, specials);
                Console.WriteLine(pass);
                Console.Read();
            }
        }

        private static string GeneratePassword(int length, bool longer, bool numbers, bool specials) {
            string Pass = string.Empty;

            string chars = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz";
            if (numbers) chars += "0123456789";
            if (specials) chars += " !#$%&()*+-/:;=><?[]{}~";

            Random rnd = new Random();

            if (longer) length = rnd.Next(length, maxLength);

            for(int i=0; i<length; i++) {
                Pass += chars[rnd.Next(chars.Length)];
            }

            return Pass;
        }
    }
}
