using Flutterwave.Constants;
using Flutterwave.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flutterwave.Moneywave.Assistants
{
    public class AccountAssistant
    {
        public Dictionary<string, string> resources = new Dictionary<string, string>();
        public AccountAssistant()
        {
            resources.Add("staging", "https://moneywave.herokuapp.com/v1/disburse");
            resources.Add("production", "http://prod1flutterwave.co:8181/pwc/rest/fw/banks/");
        }
        public async Task<string> Disburse(string @lock, string amount, string bankcode, string accountNumber, string currency, string senderName, MoneyDriver moneyDriver)
        {
            if (String.IsNullOrEmpty(moneyDriver.Token))
            {
                throw new Exception("Money Driver Token is required");
            }
            string resource = this.resources[moneyDriver.Environment];
            List<KeyValuePair<string, string>> headers = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string> (Headers.Authorization, moneyDriver.Token)
            };
            var data = new { @lock = @lock, amount = amount, bankcode = bankcode, accountNumber = accountNumber, currency = currency, senderName = senderName };
            var response = await new ApiRequest(resource).MakeRequest(data: data, method: Verbs.POST, headers: headers);
            return response;
        }
    }
}
