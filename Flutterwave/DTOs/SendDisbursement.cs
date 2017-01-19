using Flutterwave.Utilities;
namespace Flutterwave.DTOs
{
    public class SendDisbursement
    {
        public SendDisbursement(string accounttoken, string transferamount, string uniquereference, string narration, string sendername, Destination destination, string merchantid, string apikey)
        {
            this.accounttoken = Encrypt.TripleDESEncrypt(accounttoken, apikey);
            this.transferamount = Encrypt.TripleDESEncrypt(transferamount, apikey);
            this.uniquereference = Encrypt.TripleDESEncrypt(uniquereference, apikey);
            this.narration = Encrypt.TripleDESEncrypt(narration, apikey);
            this.sendername = Encrypt.TripleDESEncrypt(sendername, apikey);
            this.destbankcode = Encrypt.TripleDESEncrypt(destination.BankCode, apikey);
            this.recipientaccount = Encrypt.TripleDESEncrypt(destination.RecipientAccount, apikey);
            this.recipientname = Encrypt.TripleDESEncrypt(destination.RecipientName, apikey);
            this.country = Encrypt.TripleDESEncrypt(destination.Country, apikey);
            this.currency = Encrypt.TripleDESEncrypt(destination.Currency, apikey);
            this.merchantid = merchantid;
        }
        public string merchantid { get; set; }
        public string accounttoken { get; set; }
        public string transferamount { get; set; }
        public string uniquereference { get; set; }
        public string destbankcode { get; set; }
        public string narration { get; set; }
        public string recipientaccount { get; set; }
        public string recipientname { get; set; }
        public string sendername { get; set; }
        public string country { get; set; }
        public string currency { get; set; }
    }
}
