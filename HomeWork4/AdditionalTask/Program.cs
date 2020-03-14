using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdditionalTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string loginPattern = @"^[a-zA-z]+$";
            string passwordPattern = @"^[a-zA-z0-9]+$";
            var loginRegex = new Regex(loginPattern);
            var passwordRegex = new Regex(passwordPattern);

            string userLogin = string.Empty;
            while (true)
            {
                Console.Write("Enter login: ");
                userLogin = Console.ReadLine();
                if (!loginRegex.IsMatch(userLogin))
                {
                    Console.WriteLine("Login must contains only latin symbols. Press enter and retry");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }

                Console.Write("Enter password: ");
                string password = Console.ReadLine();
                if (!passwordRegex.IsMatch(password))
                {
                    Console.WriteLine("Password must contains only latin symbols and numbers. Press enter and retry");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }
                break;
                
            }
            Console.Clear();
            Console.WriteLine($"Welcome {userLogin}");
        }
    }
}
