using System;
using Flutterwave;
using Flutterwave.Helpers;
using Flutterwave.DTOs;
using Flutterwave.Constants;
using System.Threading.Tasks;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Driver driver = new Driver("apikey", "merchantkey", "staging");
            BankHelper bankHelper = new BankHelper();
            var response = bankHelper.AllBanks(driver).Result;
            Console.WriteLine(response);
            Console.ReadKey();
        }
    }
}
