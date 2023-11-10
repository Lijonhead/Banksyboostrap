using System;
using Banksyboostrap.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banksyboostrap.Utilities;
using Banksyboostrap.Data;

namespace Banksyboostrap
{
    internal static class AdminFunctions
    {
        public static void DoAdminTasks() 
        {
            using (BankContext context = new BankContext()) 
            {
                Console.WriteLine("Current users in system:");
                List<User> users = DbHelper.GetAllUsers(context);

                foreach (User user in users) 
                
                {
                    Console.WriteLine($"{user.Name}");
                }
                Console.WriteLine($"Total number of users = {users.Count()}");
                Console.WriteLine("c to creat new user");
                Console.WriteLine("x to exit");

                while (true)
                {
                    Console.Write("Enter command:");
                    string command = Console.ReadLine();

                    switch (command)
                    {
                        case "c":
                            CreatUser(context);
                            break;
                        case "x":
                            return;
                            
                            default: Console.WriteLine("Bad command");
                            break;
                    }
                }
            }
            
        }

        private static void CreatUser(BankContext context) 
        {
            Console.WriteLine("Creat user");
            Console.WriteLine("Enter user name:");
            string username = Console.ReadLine();

            Random random = new Random();
            string pin = random.Next(1000, 10000).ToString();
            User newUser = new User()
            {
                Name = username,
                Pin = pin
            };
            bool success = DbHelper.AddUser(context, newUser);
            if (success)
            {
                Console.WriteLine($"cCreated user {username} with pin {pin}");
            }
            else 
            {
                Console.WriteLine($"Failed to create usre with username {username}");
            }
        }

        
    }
}
