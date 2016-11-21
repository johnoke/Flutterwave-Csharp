using Flutterwave.Utilities;

namespace Flutterwave.DTOs
{
    public class CardCapture
    {
        public CardCapture(string trxreference, string trxauthorizeid, string amount, string currency, string country, string merchantid, string apikey)
        {
            this.trxreference = Encrypt.TripleDESEncrypt(trxreference, apikey);
            this.trxauthorizeid = Encrypt.TripleDESEncrypt(trxauthorizeid, apikey);
            this.amount = Encrypt.TripleDESEncrypt(amount, apikey);
            this.currency = Encrypt.TripleDESEncrypt(currency, apikey);
            this.country = Encrypt.TripleDESEncrypt(country, apikey);
            this.merchantid = merchantid;
        }
        public string trxreference { get; set; }
        public string trxauthorizeid { get; set; }
        public string amount { get; set; }
        public string currency { get; set; }
        public string country { get; set; }
        public string merchantid { get; set; }
    }
}
