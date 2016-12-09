using Flutterwave.Utilities;
namespace Flutterwave.DTOs
{
    public class ValidateBVN
    {
        public ValidateBVN(string bvn, string transactionreference, string otp, string merchantid, string apikey)
        {
            this.bvn = Encrypt.TripleDESEncrypt(bvn, apikey);
            this.transactionreference = Encrypt.TripleDESEncrypt(transactionreference, apikey);
            this.otp = Encrypt.TripleDESEncrypt(otp, apikey);
            this.merchantid = merchantid;
        }
        public string bvn { get; set; }
        public string transactionreference { get; set; }
        public string otp { get; set; }
        public string merchantid { get; set; }
    }
}
