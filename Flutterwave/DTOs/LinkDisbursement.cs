using Flutterwave.Utilities;
namespace Flutterwave.DTOs
{
    public class LinkDisbursement
    {
        public LinkDisbursement(string accountnumber, string merchantid, string apikey)
        {
            this.accountnumber = Encrypt.TripleDESDecrypt(accountnumber, apikey);
            this.merchantid = merchantid;
        }
        public string accountnumber { get; set; }
        public string merchantid { get; set; }
    }
}
