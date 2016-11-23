using System.Collections.Generic;
using System.Threading.Tasks;
using Flutterwave.Operations;
using Flutterwave.Utilities;
using Flutterwave.Constants;
using Flutterwave.DTOs;

namespace Flutterwave.Helpers
{
    public class AccessAccountHelper
    {
        public Dictionary<string, AccessAccountOperation> resources = new Dictionary<string, AccessAccountOperation>();
        public AccessAccountHelper()
        {
            resources.Add("staging", new AccessAccountOperation
            {
                Initiate = "http://staging1flutterwave.co:8080/pwc/rest/pay/resolveaccount",
                Validate = "http://staging1flutterwave.co:8080/pwc/rest/account/pay",
                Charge = "http://staging1flutterwave.co:8080/pwc/rest/account/pay/validate"
            });
            resources.Add("production", new AccessAccountOperation
            {
                Initiate = "https://prod1flutterwave.co:8181/pwc/rest/pay/resolveaccount",
                Validate = "https://prod1flutterwave.co:8181/pwc/rest/account/pay",
                Charge = "https://prod1flutterwave.co:8181/pwc/rest/account/pay/validate"
            });
        }
        public async Task<string> Initiate(string accountNumber, Driver driver)
        {
            string resource = this.resources[driver.Env].Initiate;
            var initiateData = new { accountNumber = Encrypt.TripleDESEncrypt(accountNumber, driver.ApiKey), merchantid = driver.MerchantKey };
            var response = await new ApiRequest(resource).MakeRequest(method: Verbs.POST, data: initiateData);
            return response;
        }
        public async Task<string> Validate(string reference, string accountNo, string otp, string amount, string narration, Driver driver)
        {
            string resource = this.resources[driver.Env].Validate;
            ValidateAccessCharge validateAccessCharge = new ValidateAccessCharge(otp, accountNo, reference, amount, narration, driver.MerchantKey, driver.ApiKey);
            var response = await new ApiRequest(resource).MakeRequest(method: Verbs.POST, data: validateAccessCharge);
            return response;
        }
        public async Task<string> Charge(string token, string amount, string narration, Driver driver)
        {
            string resource = this.resources[driver.Env].Validate;
            AccessAccountCharge accessAccountCharge = new AccessAccountCharge(token, amount, narration, driver.MerchantKey, driver.ApiKey);
            var response = await new ApiRequest(resource).MakeRequest(method: Verbs.POST, data: accessAccountCharge);
            return response;
        }
    }
}
