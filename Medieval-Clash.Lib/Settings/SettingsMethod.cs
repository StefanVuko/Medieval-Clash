using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medieval_Clash.Lib.Settings
{
    internal class SettingsMethod
    {
          static string ChangeUsername(string userName)
        {
            Console.WriteLine("Current username:" + userName);
            Console.Write("If you want to change your username, type in `yes´, if not `no´.");
            string answer = Console.ReadLine();

            if (answer == "yes") {
                Console.Write("Perfect, now type in your new Username:");
                userName = Console.ReadLine();
                Console.WriteLine("Your new username is:" + userName);
                return userName;
            } else if (answer == "no") { 
               Console.WriteLine("Okay, see you later");
            } else
            {
                Console.WriteLine("I couldn't understand your answer. Please try again.");
                ChangeUsername(userName);
            }
            return userName;
        }

        private static void Main(string[] args)
        {
            Console.WriteLine(ChangeUsername("Anna"));
        }

    } 
}
