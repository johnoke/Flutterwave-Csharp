using System;
using Flutterwave;
using Flutterwave.Helpers;
using Flutterwave.DTOs;
using Flutterwave.Constants;
using System.Threading.Tasks;
using Flutterwave.Moneywave.Assistants;
using Flutterwave.Moneywave.CommunicationObjects;
using Flutterwave.Moneywave;
using Newtonsoft.Json;

namespace Example
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Driver driver = new Driver("apkey", "merchantkey", "staging");
            BankHelper bankHelper = new BankHelper();
            var response = bankHelper.AllBanks(driver).Result;
            Console.ReadKey();
        }
        
    }
}
