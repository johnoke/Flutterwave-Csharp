using System;
using Flutterwave.Constants;

namespace Flutterwave
{
    public class Driver
    {
        public string ApiKey { get; set; }
        public string MerchantKey { get; set; }
        public string Env { get; set; }

        public Driver(string env, string apiKey = null, string merchantKey = null)
        {
            if (String.IsNullOrEmpty(apiKey))
            {
                throw new Exception("API Key is required");
            }
            if (String.IsNullOrEmpty(merchantKey))
            {
                throw new Exception("Merchant Key is required");
            }
            Environments.validateEnvironment(env);
            this.Env = env;
            this.ApiKey = apiKey;
            this.MerchantKey = merchantKey;
        }

        public bool HasMerchantKey()
        {
            return !String.IsNullOrEmpty(this.MerchantKey);
        }

        public bool HasAPIKey()
        {
            return !String.IsNullOrEmpty(this.ApiKey);
        }

        public void ValidateClientCredentials()
        {
            if (!(this.HasMerchantKey() && this.HasAPIKey()))
            {
                throw new Exception("You need to set Credentials First, Use The Overload Driver(string, string, string)");
            }
        }
    }
}
