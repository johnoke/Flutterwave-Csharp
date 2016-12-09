namespace Flutterwave.DTOs
{
    public class Card
    {
        public Card(string cardNumber, string expiryMonth, string expiryYear, string cvv, string cardType, string pin, string bvn)
        {
            this.CardNumber = cardNumber;
            this.ExpiryMonth = expiryMonth;
            this.ExpiryYear = expiryYear;
            this.CVV = cvv;
            this.CardType = cardType;
            this.PIN = pin;
            this.BVN = bvn;
        }
        public Card(string cardNumber, string expiryMonth, string expiryYear, string cvv)
        {
            this.CardNumber = cardNumber;
            this.ExpiryMonth = expiryMonth;
            this.ExpiryYear = expiryYear;
            this.CVV = cvv;
        }
        public string CardNumber { get; set; }
        public string ExpiryMonth { get; set; }
        public string ExpiryYear { get; set; }
        public string CardType { get; set; }
        public string PIN { get; set; }
        public string BVN { get; set; }
        public string CVV { get; set; }
    }
}
