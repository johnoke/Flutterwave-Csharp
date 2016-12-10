using Flutterwave.Constants;
using Flutterwave.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flutterwave.Utilities.Api;

namespace Flutterwave.Helpers
{
    public class BINHelper
    {
        public Dictionary<string, string> resources = new Dictionary<string, string>();
        public BINHelper()
        {
            resources.Add(Environments.Staging, "http://staging1flutterwave.co:8080/pwc/rest/fw/check/");
            resources.Add(Environments.Production, "https://prod1flutterwave.co:8181/pwc/rest/fw/check/");
        }
        public async Task<string> Check(string firstSixDigits, Driver driver)
        {
            string resource = this.resources[driver.Env];
            var response = await new Request(resource).MakeRequest(method: Verbs.POST, data: new { card6 = firstSixDigits });
            return response;
        }
    }
}
