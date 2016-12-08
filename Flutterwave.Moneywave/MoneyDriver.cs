using System;

namespace Flutterwave.Moneywave
{
    public class MoneyDriver
    {
        public string ApiKey { get; set; }
        public string Secret { get; set; }
        public string Token { get; set; }
        public string Environment { get; set; }
        public MoneyDriver(string apiKey, string secret, string environment, string token = null)
        {
            if (String.IsNullOrEmpty(apiKey))
            {
                throw new Exception("Api Key is required");
            }
            if (String.IsNullOrEmpty(secret))
            {
                throw new Exception("Secret Key is required");
            }
            if (String.IsNullOrEmpty(environment))
            {
                throw new Exception("Environment is required");
            }
            this.ApiKey = apiKey;
            this.Secret = secret;
            this.Environment = environment;
            this.Token = token;
        }
    }
}
