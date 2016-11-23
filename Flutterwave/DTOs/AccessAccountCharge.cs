using Flutterwave.Utilities;
namespace Flutterwave.DTOs
{
    public class AccessAccountCharge
    {
        public AccessAccountCharge(string accounttoken, string amount, string narration, string merchantid, string apikey)
        {
            this.accountToken = Encrypt.TripleDESEncrypt(accounttoken, apikey);
            this.billingamount = Encrypt.TripleDESEncrypt(amount, apikey);
            this.debitnarration = Encrypt.TripleDESEncrypt(narration, apikey);
            this.merchantid = merchantid;
        }
        public string accountToken { get; set; }
        public string billingamount { get; set; }
        public string debitnarration { get; set; }
        public string merchantid { get; set; }
    }
}
