using Flutterwave.Constants;
using Flutterwave.DTOs;
using Flutterwave.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flutterwave.Operations;
using Flutterwave.Utilities.Api;

namespace Flutterwave.Helpers
{
    public class DisbursementHelper
    {
        public Dictionary<string, DisbursementOperation> resources = new Dictionary<string, DisbursementOperation>();
        public DisbursementHelper()
        {
            resources.Add(Environments.Staging, new DisbursementOperation
            {
                Link = "http://staging1flutterwave.co:8080/pwc/rest/pay/linkaccount/",
                Validate = "http://staging1flutterwave.co:8080/pwc/rest/pay/linkaccount/validate/",
                GetLinkedAccounts = "http://staging1flutterwave.co:8080/pwc/rest/pay/getlinkedaccounts",
                Send = "http://staging1flutterwave.co:8080/pwc/rest/pay/send"
            });
            resources.Add(Environments.Production, new DisbursementOperation
            {
                Link = "https://prod1flutterwave.co:8181/pwc/rest/pay/linkaccount/",
                Validate = "https://prod1flutterwave.co:8181/pwc/rest/pay/linkaccount/validate/",
                GetLinkedAccounts = "https://prod1flutterwave.co:8181/pwc/rest/pay/getlinkedaccounts",
                Send = "https://prod1flutterwave.co:8181/pwc/rest/pay/send"
            });
        }
        public async Task<string> Link(string accountno, Driver driver)
        {
            string resource = this.resources[driver.Env].Link;
            LinkDisbursement linkDisbursement = new LinkDisbursement(accountno, driver.MerchantKey, driver.ApiKey);
            var response = await new Request(resource).MakeRequest(data: linkDisbursement, method: Verbs.POST);
            return response;
        }
        public async Task<string> Validate(string otp, string reference, Driver driver, string otptype = Verification.SMS)
        {
            string resource = this.resources[driver.Env].Validate;
            ValidateDisbursement disbursement = new ValidateDisbursement(otp, reference, otptype, driver.MerchantKey, driver.ApiKey);
            var response = await new Request(resource).MakeRequest(data: disbursement, method: Verbs.POST);
            return response;
        }
        public async Task<string> GetLinkedAccounts(Driver driver)
        {
            string resource = this.resources[driver.Env].GetLinkedAccounts;
            var linkedAccountData = new { merchantid = driver.MerchantKey };
            var response = await new Request(resource).MakeRequest(data: linkedAccountData, method: Verbs.POST);
            return response;
        }
        public async Task<string> Send(string accounttoken, string uniqueref, string amount, string narration, string sendername, Destination destination, Driver driver)
        {
            string resource = this.resources[driver.Env].Send;
            SendDisbursement disbursement = new SendDisbursement(accounttoken, amount, uniqueref, narration, sendername, destination, driver.MerchantKey, driver.ApiKey);
            var response = await new Request(resource).MakeRequest(data: disbursement, method: Verbs.POST);
            return response;
        }
    }
}
