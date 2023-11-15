using Banksyboostrap.Data;
using Banksyboostrap.Models;
using Banksyboostrap.Utilities;

namespace Banksyboostrap

{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Banksy bank");
            Console.WriteLine("Please log in");
            Console.Write("Enter username:");
            string userName = Console.ReadLine();

            Console.Write("Enter pin code:");
            string pin = Console.ReadLine();

            if (userName == "admin") 
            {
                if (pin != "1234") 
                { 
                    Console.WriteLine("Wrong pin code");
                    return;
                }
                AdminFunctions.DoAdminTasks();
                return;
            }
            // Code here for user login ***

            

            // Inside the Main method in the Banksyboostrap namespace

            using (BankContext context = new BankContext())
            {
                User currentUser = DbHelper.GetUserByUsername(context, userName);

                if (currentUser != null && currentUser.Pin == pin)
                {
                    Console.WriteLine($"Login successful. Welcome, {currentUser.Name}!");

                    bool loggedIn = true;

                    while (loggedIn)
                    {
                        Console.WriteLine("\nSelect an option:");
                        Console.WriteLine("1. View your accounts and balance");
                        Console.WriteLine("2. Transfer between accounts");
                        Console.WriteLine("3. Withdraw money");
                        Console.WriteLine("4. Deposit money");
                        Console.WriteLine("5. Open new account");
                        Console.WriteLine("6. Log out");

                        Console.Write("  Enter option number: ");
                        string option = Console.ReadLine();

                        switch (option)
                        {
                            case "1": // View accounts and balance
                                BankOperations.SeeAccountsAndBalance(currentUser);
                                break;

                            case "2": // Transfer between accounts
                                Console.WriteLine("Enter source account ID:");
                                int sourceAccountId = int.Parse(Console.ReadLine());

                                Console.WriteLine("Enter target account ID:");
                                int targetAccountId = int.Parse(Console.ReadLine());

                                Console.WriteLine("Enter transfer amount:");
                                double transferAmount = double.Parse(Console.ReadLine());

                                Account sourceAccount = currentUser.Accounts.FirstOrDefault(a => a.Id == sourceAccountId);
                                Account targetAccount = currentUser.Accounts.FirstOrDefault(a => a.Id == targetAccountId);

                                if (sourceAccount != null && targetAccount != null)
                                {
                                    BankOperations.TransferBetweenAccounts(sourceAccount, targetAccount, transferAmount);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid account IDs. Transfer failed.");
                                }
                                break;
                                

                            case "3": // Withdraw money
                                Console.WriteLine("Enter account ID for withdrawal:");
                                int withdrawalAccountId = int.Parse(Console.ReadLine());

                                Console.WriteLine("Enter withdrawal amount:");
                                double withdrawalAmount = double.Parse(Console.ReadLine());

                                Account withdrawalAccount = currentUser.Accounts.FirstOrDefault(a => a.Id == withdrawalAccountId);

                                if (withdrawalAccount != null)
                                {
                                    BankOperations.WithdrawMoney(withdrawalAccount, withdrawalAmount);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid account ID. Withdrawal failed.");
                                }
                                
                                break;

                            case "4": // Deposit money
                                Console.WriteLine("Enter account ID for deposit:");
                                int depositAccountId = int.Parse(Console.ReadLine());

                                Console.WriteLine("Enter deposit amount:");
                                double depositAmount = double.Parse(Console.ReadLine());

                                Account depositAccount = currentUser.Accounts.FirstOrDefault(a => a.Id == depositAccountId);

                                if (depositAccount != null)
                                {
                                    BankOperations.DepositMoney(depositAccount, depositAmount);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid account ID. Deposit failed.");
                                }
                                break;

                            case "5": // Open new account
                                BankOperations.OpenNewAccount(context, currentUser);
                                break;

                            case "6": // Log out
                                loggedIn = false;
                                Console.WriteLine("Logged out. Goodbye!");
                                break;

                            default:
                                Console.WriteLine("Invalid option. Please try again.");
                                break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid username or pin. Login failed.");
                }
            }

        }
    }
}