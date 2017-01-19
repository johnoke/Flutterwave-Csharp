using Flutterwave.Utilities;
namespace Flutterwave.DTOs
{
    public class ResendOTPBVN
    {
        public ResendOTPBVN(string validateoption, string transactionreference, string merchantid, string apikey)
        {
            this.validateoption = Encrypt.TripleDESEncrypt(validateoption, apikey);
            this.transactionreference = Encrypt.TripleDESEncrypt(transactionreference, apikey);
            this.merchantid = merchantid;
        }
        public string validateoption { get; set; }
        public string transactionreference { get; set; }
        public string merchantid { get; set; }
    }
}
