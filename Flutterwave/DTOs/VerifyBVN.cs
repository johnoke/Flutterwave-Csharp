using Flutterwave.Utilities;
namespace Flutterwave.DTOs
{
    public class VerifyBVN
    {
        public VerifyBVN(string otpoption, string bvn, string merchantid, string apikey)
        {
            this.otpoption = Encrypt.TripleDESEncrypt(otpoption, apikey);
            this.bvn = Encrypt.TripleDESEncrypt(bvn, apikey);
            this.merchantid = merchantid;
        }
        public string otpoption { get; set; }
        public string bvn { get; set; }
        public string merchantid { get; set; }
    }
}
