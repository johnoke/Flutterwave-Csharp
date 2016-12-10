<<<<<<< HEAD
﻿using System;
using Flutterwave;
using Flutterwave.Helpers;
using Flutterwave.DTOs;
using Flutterwave.Constants;
using System.Threading.Tasks;
using Flutterwave.Moneywave.Assistants;
using Flutterwave.Moneywave.CommunicationObjects;
using Flutterwave.Moneywave;
using Newtonsoft.Json;
using Flutterwave.Utilities;

namespace Example
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var driver = new Driver("tk_7df5SIHivB3QD9mckoUt", "tk_fkDzZdBoxQ", "staging");
            var assistant = new VerificationAssistant();
            var accountAssistant = new AccountAssistant();

            var moneyDriver = new MoneyDriver("B7PA0ZWYBBJ8LY1FIIJA", "HVEJ9IQVUW7WUMWKCJ9EKJDW741GDA", "staging");
            //moneyDriver = GenerateToken(moneyDriver);
            //var response = accountAssistant.Disburse("w@ll3tlife", "50", "044", "0690000005", "NGN", "Wallet.ng", moneyDriver).Result;
            //DisbursementHelper disbursementHelper = new DisbursementHelper();
            AccountHelper accountHelper = new AccountHelper();
            var cardHelper = new CardHelper();
            var card = new Card("5377283645077450", "08", "19", "428", "MasterCard", "1111", "");
            //var response = cardHelper.Charge(card, "100", "2347068264085", Currencies.NAIRA, Countries.NIGERIA, "VBVSECURECODE", "test", driver, responseUrl: "http://localhost:32843/testvbsecurecode.html").Result;
            var response = "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";
            response = Encrypt.TripleDESDecrypt(response, driver.ApiKey);
            //Destination destination = new Destination
            //{
            //    BankCode = "058", 
            //    Country = Countries.NIGERIA,
            //    Currency = Currencies.NAIRA,
            //    RecipientAccount = "0123453241",
            //    RecipientName = "Ridwan Olalere"
            //};
            //BVNHelper helper = new BVNHelper();
            //var response = helper.Validate("22254824829", "78215", "FLW00291016", driver).Result;
            //var response = disbursementHelper.Send("FLWT00373567", "23323234547873436", "10", "Testing", "Godswill Okwara", destination, driver).Result;
            Console.WriteLine(response);
            //PaymentDetails details = new PaymentDetails
            //{
            //    Amount = "1000",
            //    Currency = "NGN",
            //    Email = "dd@gmail.com",
            //    FirstName = "John",
            //    LastName = "Oke",
            //    Narration = "Test Narration"
            //};
            //try
            //{
            //    //string response = accountHelper.Charge("0690000031", "044", "", details, DateTime.Now.ToString("ddMMyyyyhhmmss"), driver).Result;
            //    var response = accountHelper.Validate("12345", "02122016120431", driver).Result;
            //    Console.WriteLine(response);
            //    Console.ReadKey();
            //}
            //catch (TaskCanceledException ex)
            //{
            //    Console.WriteLine(ex.ToString());
            //}
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
=======
﻿using System;
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
>>>>>>> 50ce768f59cf5cb025831deaf220bf221998f2ae
