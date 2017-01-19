using Flutterwave.Constants;
using Flutterwave.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Flutterwave.Helpers
{
    public class BankHelper
    {
        public Dictionary<string, string> resources = new Dictionary<string, string>();
        public BankHelper()
        {
            resources.Add("staging", "http://staging1flutterwave.co:8080/pwc/rest/fw/banks/");
            resources.Add("production", "https://prod1flutterwave.co:8181/pwc/rest/fw/banks/");
        }
        public async Task<string> AllBanks(Driver driver)
        {
            string resource = this.resources[driver.Env];
            var response =  await new ApiRequest(resource).MakeRequest(method: Verbs.POST);
            return response;
        }
    }
}
