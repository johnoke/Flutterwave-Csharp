using System;
using Flutterwave;
using Flutterwave.Helpers;
namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Driver driver = new Driver("staging");
            BankHelper bankHelper = new BankHelper();
            string response = bankHelper.AllBanks(driver).Result;
            Console.WriteLine(response);
            Console.ReadKey();
        }
    }
}
