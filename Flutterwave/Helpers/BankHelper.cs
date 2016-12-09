using Flutterwave.Constants;
using Flutterwave.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flutterwave.Utilities.Api;

namespace Flutterwave.Helpers
{
    public class BankHelper
    {
        public Dictionary<string, string> resources = new Dictionary<string, string>();
        public BankHelper()
        {
            resources.Add(Environments.Staging, "http://staging1flutterwave.co:8080/pwc/rest/fw/banks/");
            resources.Add(Environments.Production, "http://prod1flutterwave.co:8181/pwc/rest/fw/banks/");
        }
        public async Task<string> AllBanks(Driver driver)
        {
            string resource = this.resources[driver.Env];
            var response =  await new Request(resource).MakeRequest(method: Verbs.POST);
            return response;
        }
    }
}
