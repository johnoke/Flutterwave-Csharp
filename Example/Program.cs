using System;
using Flutterwave;
using Flutterwave.Helpers;
using Flutterwave.Constants;
namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Driver driver = new Driver(Environments.Staging);
            BankHelper bankHelper = new BankHelper();
            string response = bankHelper.AllBanks(driver).Result;
            Console.WriteLine(response);
            Console.ReadKey();
        }
    }
}
