using Flutterwave.Utilities;
namespace Flutterwave.DTOs
{
    public class ValidateAccountCharge
    {
        public ValidateAccountCharge(string otp, string reference, string apikey, string merchantid)
        {
            this.otp = Encrypt.TripleDESEncrypt(otp, apikey);
            this.transactionreference = Encrypt.TripleDESEncrypt(reference, apikey);
            this.merchantid = merchantid;
        }
        public string otp { get; set; }
        public string transactionreference { get; set; }
        public string merchantid { get; set; }
    }
}
