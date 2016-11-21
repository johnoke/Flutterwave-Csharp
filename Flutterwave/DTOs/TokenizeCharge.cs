using Flutterwave.Utilities;
namespace Flutterwave.DTOs
{
    public class TokenizeCharge
    {
        public TokenizeCharge(Card card, string authmodel, string validateoption, string bvn, string merchantid, string apikey)
        {
            this.cardno = Encrypt.TripleDESEncrypt(card.CardNumber, apikey);
            this.cvv = Encrypt.TripleDESEncrypt(card.CVV, apikey);
            this.expirymonth = Encrypt.TripleDESEncrypt(card.ExpiryMonth, apikey);
            this.expiryyear = Encrypt.TripleDESEncrypt(card.ExpiryYear, apikey);
            this.authmodel = Encrypt.TripleDESEncrypt(authmodel, apikey);
            this.bvn = Encrypt.TripleDESEncrypt(bvn, apikey);
            this.merchantid = merchantid;
        }
        public string cardno { get; set; }
        public string cvv { get; set; }
        public string expirymonth { get; set; }
        public string expiryyear { get; set; }
        public string authmodel { get; set; }
        public string validateoption { get; set; }
        public string bvn { get; set; }
        public string merchantid { get; set; }
    }
}
