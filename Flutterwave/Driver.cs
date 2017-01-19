using System;
namespace Flutterwave
{
    public class Driver
    {
        public string ApiKey { get; set; }
        public string MerchantKey { get; set; }
        public string Env { get; set; } 
        public Driver(string apiKey, string merchantKey, string env)
        {
            if (String.IsNullOrEmpty(apiKey))
            {
                throw new Exception("API Key is required");
            }
            if (String.IsNullOrEmpty(merchantKey))
            {
                throw new Exception("Merchant Key is required");
            }
            if (String.IsNullOrEmpty(env) || (env != "staging" && env != "production"))
            {
                throw new Exception("Env variable can only be staing or production");
            }
            this.ApiKey = apiKey;
            this.MerchantKey = merchantKey;
            this.Env = env;
            
        }
        public Driver(string env)
        {
            if (String.IsNullOrEmpty(env) || (env != "staging" && env != "production"))
            {
                throw new Exception("Env variable can only be staing or production");
            }
            this.Env = env;
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
