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
            Driver driver = new Driver("lk_kwaAqTQLRDsNp6M139xK", "lk_I2bHNkOsBR", "production");
            //CardHelper cardHelper = new CardHelper();
            //Card card = new Card("4960092301028681", "04", "19", "136");
            //card.PIN = "2006";
            //var response = cardHelper.Charge(card, "100", "2347068264085", Currencies.NAIRA, Countries.NIGERIA, "RANDOM_DEBIT", "Wallet.ng Payment", driver, "").Result;
            //var response = cardHelper.Validate("FLW04123206", "2.20", "Verve", driver).Result;
            //Console.WriteLine(response);
            //AccountHelper helper = new AccountHelper();
            //var response = helper.Enquire("011", "3053237924", driver).Result;
            MoneyDriver moneyDriver = new MoneyDriver("7PQSESSQBNQ50QWQ1QWN", "551JT3VNALM713Q5L8LNM2ICI5S9MF", "production");
            moneyDriver = GenerateDisbursementToken(moneyDriver);
            Disburse(moneyDriver);
            //Console.WriteLine(moneyDriver.Token);
            //CardHelper cardHelper = new CardHelper();
            //var response = cardHelper.CheckStatus("FLW04851831", driver).Result;
            //Console.WriteLine(response);
            //VerifyBankAccount();
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
        public static void CheckAccessBankCharge()  
        {
            AccountHelper accountCharge = new AccountHelper();
            PaymentDetails details = new PaymentDetails
            {
                Amount = "100",
                Currency = Currencies.NAIRA,
                Email = "okejohn.oluranti@gmail.com",
                FirstName = "John",
                LastName = "Oke",
                Narration = "User Topped up Wallet.ng Account "
            };
            Driver driver = new Driver("lk_kwaAqTQLRDsNp6M139xK", "lk_I2bHNkOsBR", "production");
            AccountHelper accountHelper = new AccountHelper();
            var response = accountHelper.Charge("0700370937", "044", "", details, "4222130003344", driver).Result;
            Console.WriteLine(response);
        }
        public static void ValidateBankCharge()
        {
            AccountHelper accountCharge = new AccountHelper();
            PaymentDetails details = new PaymentDetails
            {
                Amount = "100",
                Currency = Currencies.NAIRA,
                Email = "okejohn.oluranti@gmail.com",
                FirstName = "John",
                LastName = "Oke",
                Narration = "User Topped up Wallet.ng Account "
            };
            Driver driver = new Driver("lk_kwaAqTQLRDsNp6M139xK", "lk_I2bHNkOsBR", "production");
            AccountHelper accountHelper = new AccountHelper();
            var response = accountHelper.Validate("319942", "4222130003344", driver).Result;
            Console.WriteLine(response);
        }
        public static void VerifyBankAccount()
        {
            MoneyDriver driver = new MoneyDriver("7PQSESSQBNQ50QWQ1QWN", "551JT3VNALM713Q5L8LNM2ICI5S9MF", "production");
            driver = GenerateDisbursementToken(driver);
            AccountAssistant accountAssistant = new AccountAssistant();
            var responseStr = accountAssistant.Resolve("3053237924", "011", driver).Result;
            Console.WriteLine(responseStr);
        }
        public static MoneyDriver GenerateDisbursementToken(MoneyDriver moneyDriver)
        {
            VerificationAssistant assistant = new VerificationAssistant();
            var response = assistant.Generate(moneyDriver).Result;
            VerificationTokenResponse tokenResponse = JsonConvert.DeserializeObject<VerificationTokenResponse>(response);
            moneyDriver.Token = tokenResponse.token;
            Console.WriteLine(moneyDriver.Token);
            return moneyDriver;
        }
        public static void Disburse(MoneyDriver moneyDriver)
        {
            AccountAssistant accountAssistant = new AccountAssistant();
            var response = accountAssistant.Disburse("w@ll3tlife", "200", "063", "0063228895", Currencies.NAIRA, "John Oke", moneyDriver).Result;
            Console.WriteLine(response);
        }
    }
}
