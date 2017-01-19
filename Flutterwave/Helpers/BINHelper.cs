using Flutterwave.Constants;
using Flutterwave.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Flutterwave.Helpers
{
    public class BINHelper
    {
        public Dictionary<string, string> resources = new Dictionary<string, string>();
        public BINHelper()
        {
            resources.Add("staging", "http://staging1flutterwave.co:8080/pwc/rest/fw/check/");
            resources.Add("production", "https://prod1flutterwave.co:8181/pwc/rest/fw/check/");
        }
        public async Task<string> Check(string firstSixDigits, Driver driver)
        {
            string resource = this.resources[driver.Env];
            var response = await new ApiRequest(resource).MakeRequest(method: Verbs.POST, data: new { card6 = firstSixDigits });
            return response;
        }
    }
}
