using Flutterwave.Utilities;
namespace Flutterwave.DTOs
{
    public class AccountCharge
    {
        public AccountCharge(PaymentDetails paymentDetails, string accountNumber, string bankCode, string passCode, string reference, string merchantId, string apiKey)
        {
            this.narration = Encrypt.TripleDESEncrypt(paymentDetails.Narration, apiKey);
            this.accountnumber = Encrypt.TripleDESEncrypt(accountNumber, apiKey);
            this.bankcode = Encrypt.TripleDESEncrypt(bankCode, apiKey);
            this.passcode = Encrypt.TripleDESEncrypt(passCode, apiKey);
            this.amount = Encrypt.TripleDESEncrypt(paymentDetails.Amount, apiKey);
            this.currency = Encrypt.TripleDESEncrypt(paymentDetails.Currency, apiKey);
            this.firstname = Encrypt.TripleDESEncrypt(paymentDetails.FirstName, apiKey);
            this.lastname = Encrypt.TripleDESEncrypt(paymentDetails.LastName, apiKey);
            this.email = Encrypt.TripleDESEncrypt(paymentDetails.Email, apiKey);
            this.transactionreference = Encrypt.TripleDESEncrypt(reference, apiKey);
            this.merchantid = merchantId;
        }
        public string narration { get; set; }
        public string accountnumber { get; set; }
        public string bankcode { get; set; }
        public string passcode { get; set; }
        public string amount { get; set; }
        public string currency { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string transactionreference { get; set; }
        public string merchantid { get; set; }
    }
}
