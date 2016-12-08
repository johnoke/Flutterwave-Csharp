using System.Collections.Generic;
using System.Threading.Tasks;
using Flutterwave.Utilities;
using Flutterwave.Constants;
namespace Flutterwave.Moneywave.Assistants
{
    public class BankAssistant
    {
        public Dictionary<string, string> resources = new Dictionary<string, string>();
        public BankAssistant()
        {
            resources.Add("staging", "https://moneywave.herokuapp.com/banks/");
            resources.Add("production", "http://prod1flutterwave.co:8181/pwc/rest/fw/banks/");
        }
        public async Task<string> GetBanks(MoneyDriver driver)
        {
            string resource = this.resources[driver.Environment];
            var response = await new ApiRequest(resource).MakeRequest(method: Verbs.POST);
            return response;
        }
    }
}
