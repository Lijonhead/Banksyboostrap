﻿using System;
using Banksyboostrap.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banksyboostrap.Data;
using Banksyboostrap.Utilities;
namespace Banksyboostrap.Utilities
{
    internal static class DbHelper
    {
        public static List<User> GetAllUsers(BankContext context)    
        {
            List<User> users = context.Users.ToList();
            return users;
        }

        public static bool AddUser(BankContext context, User user)
        { 
            context.Users.Add(user);
            try
            {
                context.SaveChanges();
            }
            catch (Exception e)
            {

                Console.WriteLine($"Error adding user: {e}");
                return false;
            }
            return true;
        }
        public static bool AddAccount(BankContext context, Account account)
        {
            context.Accounts.Add(account);
            try
            {
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error adding account: {e}");
                return false;
            }
            return true;
        }
        public static User GetUserByUsername(BankContext context, string username)
        {
            return context.Users.FirstOrDefault(u => u.Name == username);
        }
    }
}
