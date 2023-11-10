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
        }
    }
}