using Flutterwave.Utilities;

namespace Flutterwave.DTOs
{
    public class PreAuthorizeCard
    {
        public PreAuthorizeCard(string amount, string currency, string country, string chargetoken, string merchantid, string apikey)
        {
            this.amount = Encrypt.TripleDESEncrypt(amount, apikey);
            this.currency = Encrypt.TripleDESEncrypt(currency, apikey);
            this.country = Encrypt.TripleDESEncrypt(country, apikey);
            this.chargetoken = Encrypt.TripleDESEncrypt(chargetoken, apikey);
            this.merchantid = merchantid;
        }
        public string amount { get; set; }
        public string currency { get; set; }
        public string country { get; set; }
        public string chargetoken { get; set; }
        public string merchantid { get; set; }
    }
}
