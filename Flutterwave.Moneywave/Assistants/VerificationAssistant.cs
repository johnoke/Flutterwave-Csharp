using Flutterwave.Constants;
using Flutterwave.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flutterwave.Moneywave.Assistants
{
    public class VerificationAssistant
    {
        public Dictionary<string, string> resources = new Dictionary<string, string>();
        public VerificationAssistant()
        {
            resources.Add("staging", "https://moneywave.herokuapp.com/v1/merchant/verify");
            resources.Add("production", "http://prod1flutterwave.co:8181/pwc/rest/fw/banks/");
        }
        public async Task<string> Generate(MoneyDriver driver)
        {
            string resource = this.resources[driver.Environment];
            var data = new { apiKey = driver.ApiKey, secret = driver.Secret };
            var response = await new ApiRequest(resource).MakeRequest(data: data, method: Verbs.POST);
            return response;
        }
    }
}
