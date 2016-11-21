using Flutterwave.Utilities;
using System;
namespace Flutterwave.DTOs
{
    public class ChargeCard
    {
        public ChargeCard(Card card, string amount, string custid, string currency, string authmodel, string narration, string responseurl, string country,  string merchantid, string apikey)
        {
            this.amount = Encrypt.TripleDESEncrypt(amount, apikey);
            this.custid = Encrypt.TripleDESEncrypt(custid, apikey);
            this.currency = Encrypt.TripleDESEncrypt(currency, apikey);
            this.authmodel = Encrypt.TripleDESEncrypt(authmodel, apikey);
            this.narration = Encrypt.TripleDESEncrypt(narration, apikey);
            this.responseurl = Encrypt.TripleDESEncrypt(responseurl, apikey);
            this.cardno = Encrypt.TripleDESEncrypt(card.CardNumber, apikey);
            this.cardtype = String.IsNullOrEmpty(card.CardType) ? "" : Encrypt.TripleDESEncrypt(card.CardType, apikey);
            this.cvv = Encrypt.TripleDESEncrypt(card.CVV, apikey);
            this.country = Encrypt.TripleDESEncrypt(country, apikey);
            this.expiryyear = Encrypt.TripleDESEncrypt(card.ExpiryYear, apikey);
            this.expirymonth = Encrypt.TripleDESEncrypt(card.ExpiryMonth, apikey);
            this.pin = String.IsNullOrEmpty(card.PIN) ? "" : Encrypt.TripleDESEncrypt(card.PIN, apikey);
            this.bvn = String.IsNullOrEmpty(card.BVN) ? "" : Encrypt.TripleDESEncrypt(card.BVN, apikey);
        }
        public string amount { get; set; }
        public string custid { get; set; }
        public string currency { get; set; }
        public string authmodel { get; set; }
        public string narration { get; set; }
        public string responseurl { get; set; }
        public string cardno { get; set; }
        public string cardtype { get; set; }
        public string cvv { get; set; }
        public string country { get; set; }
        public string expiryyear { get; set; }
        public string expirymonth { get; set; }
        public string pin { get; set; }
        public string bvn { get; set; }
        public string merchantid { get; set; }
    }
}
