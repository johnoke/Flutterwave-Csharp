using System.Collections.Generic;
using System.Threading.Tasks;
using Flutterwave.Utilities;
using Flutterwave.DTOs;
using Flutterwave.Constants;
using Flutterwave.Operations;
namespace Flutterwave.Helpers
{
    public class AccountHelper
    {
        public Dictionary<string, AccountOperation> resources = new Dictionary<string, AccountOperation>();
        public AccountHelper()
        {
            resources.Add("staging", new AccountOperation {
                Enquiry = "http://staging1flutterwave.co:8080/pwc/rest/pay/resolveaccount",
                Charge = "http://staging1flutterwave.co:8080/pwc/rest/account/pay",
                Validate = "http://staging1flutterwave.co:8080/pwc/rest/account/pay/validate"
            });
            resources.Add("production", new AccountOperation
            {
                Enquiry = "https://prod1flutterwave.co:8181/pwc/rest/pay/resolveaccount",
                Charge = "https://prod1flutterwave.co:8181/pwc/rest/account/pay",
                Validate = "https://prod1flutterwave.co:8181/pwc/rest/account/pay/validate"
            });
        }
        public async Task<string> Charge(string accountNumber, string bankCode, string passCode, PaymentDetails paymentDetails , string reference, Driver driver)
        {
            string resource = this.resources[driver.Env].Charge;
            AccountCharge chargeAccount = new AccountCharge(paymentDetails, accountNumber, bankCode, passCode, reference, driver.MerchantKey, driver.ApiKey);
            var response = await new ApiRequest(resource).MakeRequest(method: Verbs.POST, data: chargeAccount);
            return response;
        }
        public async Task<string> Validate(string otp, string reference, Driver driver)
        {
            string resource = this.resources[driver.Env].Validate;
            ValidateAccountCharge validateAccountCharge = new ValidateAccountCharge(otp, reference, driver.ApiKey, driver.MerchantKey);
            var response = await new ApiRequest(resource).MakeRequest(method: Verbs.POST, data: validateAccountCharge);
            return response;
        }
        public async Task<string> Enquire(string destbankcode, string recipientaccount, Driver driver)
        {
            string resource = this.resources[driver.Env].Enquiry;
            ResolveAccount resolveAccount = new ResolveAccount(destbankcode, recipientaccount, driver.MerchantKey, driver.ApiKey);
            var response = await new ApiRequest(resource).MakeRequest(method: Verbs.POST, data: resolveAccount);
            return response;
        }
    }
}
