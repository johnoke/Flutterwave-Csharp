using Flutterwave.Utilities;

namespace Flutterwave.DTOs
{
    public class ValidateDisbursement
    {
        public ValidateDisbursement(string otp, string relatedreference, string otptype, string merchantid, string apikey)
        {
            this.otp = Encrypt.TripleDESEncrypt(otp, apikey);
            this.relatedreference = Encrypt.TripleDESEncrypt(relatedreference, apikey);
            this.merchantid = merchantid;
        }
        public string otp { get; set; }
        public string relatedreference { get; set; }
        public string otptype { get; set; }
        public string merchantid { get; set; }
    }
}
