using Flutterwave.Utilities;
namespace Flutterwave.DTOs
{
    public class ResolveAccount
    {
        public ResolveAccount(string destbankcode, string recipientaccount, string merchantid, string apikey)
        {
            this.destbankcode = Encrypt.TripleDESEncrypt(destbankcode, apikey);
            this.recipientaccount = Encrypt.TripleDESEncrypt(recipientaccount, apikey);
            this.merchantid = merchantid;
        }
        public string destbankcode { get; set; }
        public string recipientaccount  { get; set; }
        public string merchantid { get; set; }
    }
}
