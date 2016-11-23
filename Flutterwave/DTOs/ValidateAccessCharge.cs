using Flutterwave.Utilities;
namespace Flutterwave.DTOs
{
    public class ValidateAccessCharge
    {
        public ValidateAccessCharge(string otp, string accountnumber, string reference, string amount, string narration, string merchantid, string apikey)
        {
            this.otp = Encrypt.TripleDESEncrypt(otp, apikey);
            this.accountNumber = Encrypt.TripleDESEncrypt(accountnumber, apikey);
            this.billingamount = Encrypt.TripleDESEncrypt(amount, apikey);
            this.debitnarration = Encrypt.TripleDESEncrypt(narration, apikey);
            this.reference = Encrypt.TripleDESEncrypt(reference, apikey);
            this.merchantid = merchantid;
        }
        public string otp { get; set; }
        public string accountNumber { get; set; }
        public string reference { get; set; }
        public string billingamount { get; set; }
        public string debitnarration { get; set; }
        public string merchantid { get; set; }
    }
}
