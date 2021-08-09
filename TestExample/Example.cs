using AuthExample.AuthController;
using AuthExample.Utils;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.IO;

namespace AuthExample
{
    internal class Program
    {
        /// <summary>
        /// Basic example
        /// </summary>
        /// <returns></returns>
        private static async Task Main()
        {
            var key = "";

            if (File.Exists("key.json"))
            {
                key = KeySaveGrab.GetKey("key.json").KeyAuth;
            }
            else
            {
                Console.WriteLine("Key: ");

                key = Console.ReadLine();
            }

            var authSetup = await Auth.DoAuthAsync(key);

            if (!authSetup.Authenticated)
            {
                Console.WriteLine(" The key you provided was incorrect!");
                
                await Task.Delay(1000);

                Environment.Exit(0);

                return;
            }

            if (!UserGroup.UserGroups.Any(authSetup.Group.Contains))
            {
                Console.WriteLine(" You don't have the required UG! ");
                
                await Task.Delay(1000);

                Environment.Exit(0);

                return;
            }

            if (!File.Exists("key.json"))
            {
                await KeySaveGrab.SaveKeyAsync("key.json", key);
            }

            Console.WriteLine("Success!");

            await Task.Delay(-1);
        }
    }
}
