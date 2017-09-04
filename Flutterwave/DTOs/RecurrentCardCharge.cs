using Flutterwave.Utilities;
using System;
namespace Flutterwave.DTOs
{
    public class RecurrentCardCharge
    {
        public RecurrentCardCharge(string amount, string custid, string currency, string narration, string chargetoken, string country, string merchantid, string apikey, string authmodel = null, string pin = null)
        {
            this.amount = Encrypt.TripleDESEncrypt(amount, apikey);
            this.custid = Encrypt.TripleDESEncrypt(custid, apikey);
            this.currency = Encrypt.TripleDESEncrypt(currency, apikey);
            this.chargetoken = Encrypt.TripleDESEncrypt(chargetoken, apikey);
            this.narration = Encrypt.TripleDESEncrypt(narration, apikey);
            this.authmodel = String.IsNullOrEmpty(authmodel) ? "" : Encrypt.TripleDESEncrypt(authmodel, apikey);
            this.pin = String.IsNullOrEmpty(pin) ? "" : Encrypt.TripleDESEncrypt(pin, apikey);
            this.country = Encrypt.TripleDESEncrypt(country, apikey);
            this.merchantid = merchantid;
        }
        public string amount { get; set; }
        public string custid { get; set; }
        public string currency { get; set; }
        public string narration { get; set; }
        public string chargetoken { get; set; }
        public string country { get; set; }
        public string authmodel { get; set; }
        public string pin { get; set; }
        public string merchantid { get; set; }
    }
}
