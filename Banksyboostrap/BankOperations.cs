using System;
using Banksyboostrap.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banksyboostrap.Utilities;
using Banksyboostrap.Data;

namespace Banksyboostrap.Utilities
{
    internal static class BankOperations
    {
        public static void TransferBetweenAccounts(Account sourceAccount, Account targetAccount, double amount)
        {
            if (sourceAccount.Balance >= amount)
            {
                sourceAccount.Balance -= amount;
                targetAccount.Balance += amount;
                Console.WriteLine($"Transfer successful. {amount} transferred from {sourceAccount.Name} to {targetAccount.Name}");
            }
            else
            {
                Console.WriteLine("Insufficient funds for the transfer.");
            }
        }

        public static void WithdrawMoney(Account account, double amount)
        {
            if (account.Balance >= amount)
            {
                account.Balance -= amount;
                Console.WriteLine($"Withdrawal successful. {amount} withdrawn from {account.Name}");
            }
            else
            {
                Console.WriteLine("Insufficient funds for the withdrawal.");
            }
        }

        public static void DepositMoney(Account account, double amount)
        {
            account.Balance += amount;
            Console.WriteLine($"Deposit successful. {amount} deposited to {account.Name}");
        }

        public static void SeeAccountsAndBalance(User user)
        {
            Console.WriteLine($"Accounts and Balances for {user.Name}:");
            foreach (var account in user.Accounts)
            {
                Console.WriteLine($"Account ID: {account.Id}, Name: {account.Name}, Balance: {account.Balance}");
            }
        }

        public static void OpenNewAccount(BankContext context, User user)
        {
            Console.Write("Enter a name for the new account: ");
            string accountName = Console.ReadLine();

            Account newAccount = new Account
            {
                Name = accountName,
                Balance = 0,
                User = user
            };

            bool success = DbHelper.AddAccount(context, newAccount);
            if (success)
            {
                Console.WriteLine($"New account '{accountName}' created successfully.");
            }
            else
            {
                Console.WriteLine($"Failed to create a new account with the name '{accountName}'.");
            }
        }
    }
}

