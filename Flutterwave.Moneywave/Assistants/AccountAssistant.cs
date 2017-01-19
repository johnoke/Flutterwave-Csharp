using Flutterwave.Constants;
using Flutterwave.Utilities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flutterwave.Moneywave.OperationObjects;
namespace Flutterwave.Moneywave.Assistants
{
    public class AccountAssistant
    {
        public Dictionary<string, AccountOperation> resources = new Dictionary<string, AccountOperation>();
        public AccountAssistant()
        {
            resources.Add("staging", new AccountOperation {
                Disburse = "https://moneywave.herokuapp.com/v1/disburse",
                Resolve = "https://moneywave.herokuapp.com/v1/resolve/account",
            });
            resources.Add("production", new AccountOperation {
                Disburse = "https://live.moneywaveapi.co/v1/disburse",
                Resolve = "https://live.moneywaveapi.co/v1/resolve/account"
            });
        }
        public async Task<string> Disburse(string @lock, string amount, string bankcode, string accountNumber, string currency, string senderName, MoneyDriver moneyDriver)
        {
            if (String.IsNullOrEmpty(moneyDriver.Token))
            {
                throw new Exception("Money Driver Token is required");
            }
            string resource = this.resources[moneyDriver.Environment].Disburse;
            List<KeyValuePair<string, string>> headers = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string> (Headers.Authorization, moneyDriver.Token)
            };
            var data = new { @lock = @lock, amount = amount, bankcode = bankcode, accountNumber = accountNumber, currency = currency, senderName = senderName };
            var response = await new ApiRequest(resource).MakeRequest(data: data, method: Verbs.POST, headers: headers);
            return response;
        }
        public async Task<string> Resolve(string accountNumber, string bankCode, MoneyDriver moneyDriver)
        {
            string resource = this.resources[moneyDriver.Environment].Resolve;
            List<KeyValuePair<string, string>> headers = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string> (Headers.Authorization, moneyDriver.Token)
            };
            var data = new { account_number = accountNumber, bank_code = bankCode };
            var response = await new ApiRequest(resource).MakeRequest(data: data, method: Verbs.POST);
            return response;
        }
    }
    
}
