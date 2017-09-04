namespace Flutterwave.Moneywave.CommunicationObjects
{
    public class SuccessChargeCardResponse
    {
        public string status { get; set; }
        public ChargeCardResponseData data { get; set; }
        public string code { get; set; }
        public string message { get; set; }
    }
    public class ErrorChargeCardResponse {
        public string status { get; set; }
        public string data { get; set; }
        public string code { get; set; }
        public string message { get; set; }
    }
    public class TokenizeCardResponse
    {
        public string status { get; set; }
        public TokenizeCardObject data { get; set; }
    }
    public class TokenizeCardObject
    {
        public string cardToken { get; set; }
    }
    public class ChargeCardResponseData
    {
        public string authurl { get; set; }
        public string responsehtml { get; set; }
        public ChargeCardResponseDataTransfer transfer { get; set; }
        public long id { get; set; }
        public string type { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phoneNumber { get; set; }
        public string recipientPhone { get; set; }
        public bool isCardValidationSuccessful { get; set; }
        public bool isDeliverySuccessful { get; set; }
        public string status { get; set; }
        public string medium { get; set; }
        public string ip { get; set; }
        public string exchangeRate { get; set; }
        public string amountToSend { get; set; }
        public string amountToCharge { get; set; }
        public string disburseCurrency { get; set; }
        public string chargeCurrency { get; set; }
        public string flutterChargeResponseCode { get; set; }
        public string flutterChargeResponseMessage { get; set; }
        public string flutterDisburseResponseMessage { get; set; }
        public string flutterChargeReference { get; set; }
        public string flutterDisburseReference { get; set; }
        public long merchantCommission { get; set; }
        public long moneywaveCommission { get; set; }
        public long netDebitAmount { get; set; }
        public long chargedFee { get; set; }
        public string receiptNumber { get; set; }
        public string redirectUrl { get; set; }
        public string linkingReference { get; set; }
        public string createdAt { get; set; }
        public string updatedAt { get; set; }
        public string deletedAt { get; set; }
        public string userId { get; set; }
        public string merchantId { get; set; }
        public string beneficaryId { get; set; }
        public string accountId { get; set; }
        public string cardId { get; set; }
        public string account { get; set; }
        public ChargeCardDataBeneficiary beneficiary { get; set; }
    }
    public class ChargeCardResponseDataTransfer
    {
        public long id { get; set; }
        public string type { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phoneNumber { get; set; }
        public string recipientPhone { get; set; }
        public bool isCardValidationSuccessful { get; set; }
        public bool isDeliverySuccessful { get; set; }
        public string status { get; set; }
        public string medium { get; set; }
        public string ip { get; set; }
        public string exchangeRate { get; set; }
        public string amountToSend { get; set; }
        public string amountToCharge { get; set; }
        public string disburseCurrency { get; set; }
        public string chargeCurrency { get; set; }
        public string flutterChargeResponseCode { get; set; }
        public string flutterChargeResponseMessage { get; set; }
        public string flutterDisburseResponseMessage { get; set; }
        public string flutterChargeReference { get; set; }
        public string flutterDisburseReference { get; set; }
        public long merchantCommission { get; set; }
        public long moneywaveCommission { get; set; }
        public long netDebitAmount { get; set; }
        public long chargedFee { get; set; }
        public string receiptNumber { get; set; }
        public string redirectUrl { get; set; }
        public string linkingReference { get; set; }
        public string createdAt { get; set; }
        public string updatedAt { get; set; }
        public string deletedAt { get; set; }
        public string userId { get; set; }
        public string merchantId { get; set; }
        public string beneficaryId { get; set; }
        public string accountId { get; set; }
        public string cardId { get; set; }
        public string account { get; set; }
        public ChargeCardDataBeneficiary beneficiary { get; set; }
        public string authurl { get; set; }
        public string responsehtml { get; set; }
    }
    public class ChargeCardDataBeneficiary
    {
        public int id { get; set; }
        public string accountNumber { get; set; }
        public string accountName { get; set; }
        public string bankCode { get; set; }
        public string bankName { get; set; }
        public long userId { get; set; }
        public string currency { get; set; }
        public string createdAt { get; set; }
        public string updateAt { get; set; }
        public string deletedAt { get; set; }
    }
}
