using Flutterwave.Utilities;
using Flutterwave.DTOs;
using Flutterwave.Constants;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flutterwave.Operations;
namespace Flutterwave.Helpers
{
    public class BVNHelper
    {
        public Dictionary<string, BVNOperation> resources = new Dictionary<string, BVNOperation>();
        public BVNHelper()
        {
            resources.Add("staging", new BVNOperation
            {
                Verify = "http://staging1flutterwave.co:8080/pwc/rest/bvn/verify/",
                Validate = "http://staging1flutterwave.co:8080/pwc/rest/bvn/validate/",
                ResendOtp = "http://staging1flutterwave.co:8080/pwc/rest/bvn/resendotp/"
            });
            resources.Add("production", new BVNOperation
            {
                Verify = "https://prod1flutterwave.co:8181/pwc/rest/bvn/verify/",
                Validate = "https://prod1flutterwave.co:8181/pwc/rest/bvn/validate/",
                ResendOtp = "https://prod1flutterwave.co:8181/pwc/rest/bvn/resendotp/"
            });
        }
        public async Task<string> Verify(string bvn, Driver driver, string otpOption = Verification.SMS)
        {
            string resource = this.resources[driver.Env].Verify;
            VerifyBVN verifyBVN = new VerifyBVN(otpOption, bvn, driver.MerchantKey, driver.ApiKey);
            var response = await new ApiRequest(resource).MakeRequest(data: verifyBVN, method: Verbs.POST);
            return response;
        }
        public async Task<string> Validate(string bvn, string otp, string transactionReference, Driver driver)
        {
            string resource = this.resources[driver.Env].Validate;
            ValidateBVN validateBVN = new ValidateBVN(bvn, transactionReference, otp, driver.MerchantKey, driver.ApiKey);
            var response = await new ApiRequest(resource).MakeRequest(data: validateBVN, method: Verbs.POST);
            return response;
        }
        public async Task<string> ResendOtp(string transactionReference, Driver driver, string otpOption = Verification.SMS)
        {
            string resource = this.resources[driver.Env].ResendOtp;
            ResendOTPBVN resendOTPBVN = new ResendOTPBVN(otpOption, transactionReference, driver.MerchantKey, driver.ApiKey);
            var response = await new ApiRequest(resource).MakeRequest(data: resendOTPBVN, method: Verbs.POST);
            return response;
        }
    }
}
