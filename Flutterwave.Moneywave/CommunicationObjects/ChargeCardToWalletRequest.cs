namespace Flutterwave.Moneywave.CommunicationObjects
{
    public class ChargeCardToWalletRequest
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string phonenumber { get; set; }
        public string email { get; set; }
        public string recipient { get; set; }
        public string card_no { get; set; }
        public string cvv { get; set; }
        public string pin { get; set; }
        public string expiry_year { get; set; }
        public string expiry_month { get; set; }
        public string charge_auth { get; set; }
        public string apiKey { get; set; }
        public decimal amount { get; set; }
        public long fee { get; set; }
        public string medium { get; set; }
        public string redirecturl { get; set; }
    }
}
