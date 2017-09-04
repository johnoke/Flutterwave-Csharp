using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flutterwave.Moneywave.CommunicationObjects
{
    public class ChargeCardRequest
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string phonenumber { get; set; }
        public string email { get; set; }
        public string recipient { get; set; }
        public string recipient_id { get; set; }
        public string recipient_bank { get; set; }
        public string recipient_account_number { get; set; }
        public string recipients { get; set; }
        public string card_no { get; set; }
        public string cvv { get; set; }
        public string pin { get; set; }
        public string expiry_year { get; set; }
        public string expiry_month { get; set; }
        public string apiKey { get; set; }
        public long amount { get; set; }
        public long fee { get; set; }
        public string redirecturl { get; set; }
        public string medium { get; set; }
        public string chargeCurrency { get; set; }
        public string disburseCurrency { get; set; }
        public string charge_with { get; set; }
        public string card_last4 { get; set; }
        public string card_token { get; set; }
        public string sender_account_number { get; set; }
        public string sender_bank { get; set; }
        public string passcode { get; set; }
        public string card_id { get; set; }
        public string cycle { get; set; }
        public string startDate { get; set; }
        public string charge_auth { get; set; }

    }
}
