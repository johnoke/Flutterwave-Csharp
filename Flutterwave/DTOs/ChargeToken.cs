using Flutterwave.Utilities;
namespace Flutterwave.DTOs
{
    public class ChargeToken
    {
        public ChargeToken(string amount, string custid, string currency, string narration, string chargetoken, string cardtype, string country, string merchantid, string apikey)
        {
            this.amount = Encrypt.TripleDESEncrypt(amount, apikey);
            this.custid = Encrypt.TripleDESEncrypt(custid, apikey);
            this.currency = Encrypt.TripleDESEncrypt(currency, apikey);
            this.narration = Encrypt.TripleDESEncrypt(narration, apikey);
            this.chargetoken = Encrypt.TripleDESEncrypt(chargetoken, apikey);
            this.cardtype = Encrypt.TripleDESEncrypt(cardtype, apikey);
            this.country = Encrypt.TripleDESEncrypt(country, apikey);
            this.merchantid = merchantid;
        }
        public string merchantid { get; set; }
        public string amount { get; set; }
        public string custid { get; set; }
        public string currency { get; set; }
        public string narration { get; set; }
        public string chargetoken { get; set; }
        public string cardtype { get; set; }
        public string country { get; set; }
    }
}
