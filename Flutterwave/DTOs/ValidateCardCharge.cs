using Flutterwave.Utilities;
using System;
namespace Flutterwave.DTOs
{
    public class ValidateCardCharge
    {
        public ValidateCardCharge(string otptransactionidentifier, string otp, string cardtype, string merchantid, string apikey)
        {
            if (String.IsNullOrEmpty(cardtype))
            {
                throw new Exception("Card Type cannot be empty or null");
            }
            this.otptransactionidentifier = Encrypt.TripleDESEncrypt(otptransactionidentifier, apikey);
            this.otp = Encrypt.TripleDESEncrypt(otp, apikey);
            this.cardtype = Encrypt.TripleDESEncrypt(cardtype, apikey);
            this.merchantid = merchantid;
        }
        public string otptransactionidentifier { get; set; }
        public string otp { get; set; }
        public string cardtype { get; set; }
        public string merchantid { get; set; }
    }
}
