using System.Collections.Generic;
using Flutterwave.Utilities;
using System.Threading.Tasks;
using Flutterwave.DTOs;
using Flutterwave.Constants;
using Flutterwave.Operations;
using Flutterwave.Utilities.Api;

namespace Flutterwave.Helpers
{
    public class CardHelper
    {
        public Dictionary<string, CardOperation> resources = new Dictionary<string, CardOperation>();
        public CardHelper()
        {
            resources.Add(Environments.Staging, new CardOperation
            {
                Tokenize = "http://staging1flutterwave.co:8080/pwc/rest/card/mvva/tokenize/",
                Charge = "http://staging1flutterwave.co:8080/pwc/rest/card/mvva/pay/",
                Validate = "http://staging1flutterwave.co:8080/pwc/rest/card/mvva/pay/validate/",
                Preauth = "http://staging1flutterwave.co:8080/pwc/rest/card/mvva/preauthorize/",
                Capture = "http://staging1flutterwave.co:8080/pwc/rest/card/mvva/capture/",
                Refund = "http://staging1flutterwave.co:8080/pwc/rest/card/mvva/refund/",
                Status = "http://staging1flutterwave.co:8080/pwc/rest/card/mvva/status"
            });
            resources.Add(Environments.Production, new CardOperation
            {
                Tokenize = "https://prod1flutterwave.co:8181/pwc/rest/card/mvva/tokenize/",
                Charge = "https://prod1flutterwave.co:8181/pwc/rest/card/mvva/pay/",
                Validate = "https://prod1flutterwave.co:8181/pwc/rest/card/mvva/pay/validate/",
                Preauth = "https://prod1flutterwave.co:8181/pwc/rest/card/mvva/preauthorize/",
                Capture = "https://prod1flutterwave.co:8181/pwc/rest/card/mvva/capture/",
                Refund = "https://prod1flutterwave.co:8181/pwc/rest/card/mvva/refund/",
                Status = "https://prod1flutterwave.co:8181/pwc/rest/card/mvva/status"
            });
        }

        public async Task<string> Tokenize(Card card, string authModel, string validateOption, Driver driver, string bvn)
        {
            string resource = this.resources[driver.Env].Tokenize;
            TokenizeCharge tokenizeCharge = new TokenizeCharge(card, authModel, validateOption, bvn, driver.MerchantKey, driver.ApiKey);
            var response = await new Request(resource).MakeRequest(data: tokenizeCharge, method: Verbs.POST);
            return response;
        }
        public async Task<string> Charge(Card card, string amount, string custId, string currency, string country, string authModel, string narration, Driver driver, string responseUrl = "")
        {
            string resource = this.resources[driver.Env].Charge;
            ChargeCard chargeCard = new ChargeCard(card, amount, custId, currency, authModel, narration, responseUrl, country, driver.MerchantKey, driver.ApiKey);
            var response = await new Request(resource).MakeRequest(data: chargeCard, method: Verbs.POST);
            return response;
        }
        public async Task<string> Validate(string reference, string otp, string cardType, Driver driver)
        {
            string resource = this.resources[driver.Env].Validate;
            ValidateCardCharge validateCardCharge = new ValidateCardCharge(reference, otp, cardType, driver.MerchantKey, driver.ApiKey);
            var response = await new Request(resource).MakeRequest(data: validateCardCharge, method: Verbs.POST);
            return response;
        }
        public async Task<string> PreAuthorize(string token, string amount, string currency, Driver driver, string country = Countries.NIGERIA)
        {
            string resource = this.resources[driver.Env].Preauth;
            PreAuthorizeCard preAuthorizeCard = new PreAuthorizeCard(amount, currency, country, token, driver.MerchantKey, driver.ApiKey);
            var response = await new Request(resource).MakeRequest(data: preAuthorizeCard, method: Verbs.POST);
            return response;
        }
        public async Task<string> Capture(string authRef, string transId, string amount, string currency, Driver driver, string country = Countries.NIGERIA)
        {
            string resource = this.resources[driver.Env].Capture;
            CardCapture cardCapture = new CardCapture(authRef, transId, amount, currency, country, driver.MerchantKey, driver.ApiKey);
            var response = await new Request(resource).MakeRequest(data: cardCapture, method: Verbs.POST);
            return response;
        }
        public async Task<string> Refund(string authRef, string transId, string amount, string currency, Driver driver, string country = Countries.NIGERIA)
        {
            string resource = this.resources[driver.Env].Refund;
            CardCapture cardCapture = new CardCapture(authRef, transId, amount, currency, country, driver.MerchantKey, driver.ApiKey);
            var response = await new Request(resource).MakeRequest(data: cardCapture, method: Verbs.POST);
            return response;
        }
        public async Task<string> ChargeToken(string cardToken, string amount, string custid, string currency, string narration, Driver driver, string country = Countries.NIGERIA, string cardtype = "")
        {
            string resource = this.resources[driver.Env].Charge;
            ChargeToken chargeToken = new ChargeToken(amount, custid, currency, narration, cardToken, cardtype, country, driver.MerchantKey, driver.ApiKey);
            var response = await new Request(resource).MakeRequest(data: chargeToken, method: Verbs.POST);
            return response;
        }
        public async Task<string> CheckStatus(string reference, Driver driver)
        {
            string resource = this.resources[driver.Env].Status;
            var statusData = new { trxreference = Encrypt.TripleDESEncrypt(reference, driver.ApiKey), merchantid = driver.MerchantKey };
            var response = await new Request(resource).MakeRequest(data: statusData, method: Verbs.POST);
            return response;
        }
    }
}
