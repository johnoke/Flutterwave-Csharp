using Flutterwave.Constants;
using Flutterwave.Moneywave.CommunicationObjects;
using Flutterwave.Moneywave.OperationObjects;
using Flutterwave.Utilities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Flutterwave.Moneywave.Assistants
{
    public class CardAssistant
    {
        public Dictionary<string, CardOperation> resources = new Dictionary<string, CardOperation>();
        public CardAssistant()
        {
            resources.Add("staging", new CardOperation{
                ChargeCard = "https://moneywave.herokuapp.com/v1/transfer",
                ValidateCharge = "https://moneywave.herokuapp.com/v1/transfer/charge/auth/card",
                TransactionStatus = "https://moneywave.herokuapp.com/v1/transfer/{id}",
                Tokenize = "https://moneywave.herokuapp.com/v1/transfer/charge/tokenize/card",
                CardToWallet = "https://moneywave.herokuapp.com/v1/transfer"
            });
            resources.Add("production", new CardOperation
            {
                ChargeCard = "https://live.moneywaveapi.co/v1/transfer",
                ValidateCharge = "https://live.moneywaveapi.co/v1/transfer/charge/auth/card",
                TransactionStatus = "https://live.moneywaveapi.co/v1/transfer/{id}",
                Tokenize = "https://live.moneywaveapi.co/v1/transfer/charge/tokenize/card",
                CardToWallet = "https://live.moneywaveapi.co/v1/transfer",
            });
        }
        public async Task<string> Charge(ChargeCardRequest request, MoneyDriver moneyDriver)
        {
            if (String.IsNullOrEmpty(moneyDriver.Token))
            {
                throw new Exception("Money Driver Token is required");
            }
            string resource = this.resources[moneyDriver.Environment].ChargeCard;
            List<KeyValuePair<string, string>> headers = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string> (Headers.Authorization, moneyDriver.Token)
            };
            var response = await new ApiRequest(resource).MakeRequest(data: request, method: Verbs.POST, headers: headers);
            return response;
        }
        public async Task<string> ValidateCharge(ValidateChargeCardRequest request, MoneyDriver moneyDriver)
        {
            if (String.IsNullOrEmpty(moneyDriver.Token))
            {
                throw new Exception("Money Driver Token is required");
            }
            string resource = this.resources[moneyDriver.Environment].ValidateCharge;
            List<KeyValuePair<string, string>> headers = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string> (Headers.Authorization, moneyDriver.Token)
            };
            var response = await new ApiRequest(resource).MakeRequest(data: request, method: Verbs.POST, headers: headers);
            return response;
        }
        public async Task<string> TransactionStatus(string id, MoneyDriver moneyDriver)
        {
            if (String.IsNullOrEmpty(moneyDriver.Token))
            {
                throw new Exception("Money Driver Token is required");
            }
            string resource = this.resources[moneyDriver.Environment].TransactionStatus;
            resource = resource.Replace("{id}", id);
            List<KeyValuePair<string, string>> headers = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string> (Headers.Authorization, moneyDriver.Token)
            };
            var response = await new ApiRequest(resource).MakeRequest(method: Verbs.POST, headers: headers);
            return response;
        }
        public async Task<string> TokenizeCard(TokenizeCardRequest cardRequest, MoneyDriver moneyDriver)
        {
            if (String.IsNullOrEmpty(moneyDriver.Token))
            {
                throw new Exception("Money Driver Token is required");
            }
            string resource = this.resources[moneyDriver.Environment].Tokenize;
            List<KeyValuePair<string, string>> headers = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string> (Headers.Authorization, moneyDriver.Token)
            };
            var response = await new ApiRequest(resource).MakeRequest(data: cardRequest, method: Verbs.POST, headers: headers);
            return response;
        }
        public async Task<string> ChargeCardToWallet(ChargeCardToWalletRequest cardRequest, MoneyDriver moneyDriver)
        {
            if (String.IsNullOrEmpty(moneyDriver.Token))
            {
                throw new Exception("Money Driver Token is required");
            }
            string resource = this.resources[moneyDriver.Environment].CardToWallet;
            List<KeyValuePair<string, string>> headers = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string> (Headers.Authorization, moneyDriver.Token)
            };
            var response = await new ApiRequest(resource).MakeRequest(data: cardRequest, method: Verbs.POST, headers: headers);
            return response;
        }
    }
}
