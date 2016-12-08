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
            Driver driver = new Driver("apikey", "merchantkey", "staging");
            BankHelper bankHelper = new BankHelper();
            var response = bankHelper.AllBanks(driver).Result;
            Console.WriteLine(response);
            Console.ReadKey();
        }
        public static MoneyDriver GenerateToken(MoneyDriver driver)
        {
            VerificationAssistant assistant = new VerificationAssistant();
            var response = assistant.Generate(driver).Result;
            VerificationTokenResponse tokenResponse = JsonConvert.DeserializeObject<VerificationTokenResponse>(response);
            driver.Token = tokenResponse.token;
            Console.WriteLine(driver.Token);
            return driver;
        }
    }
}
