using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flutterwave.Moneywave.CommunicationObjects
{
    public class TransactionStatusResponse
    {
        public string status { get; set; }
        public TransactionStatusData data { get; set; }
        public string message { get; set; }
    }
    public class TransactionStatusData
    {
        public string id { get; set; }
        public string type { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }    
        public string phoneNumber { get; set; }
        public string recipientPhone { get; set; }
        public bool isCardValidationSuccessful { get; set; }
        public bool isDeliverySuccessful { get; set; }
        public string status { get; set; }
        public string medium { get; set; }
        public string amountToSend { get; set; }
        public string amountToCharge { get; set; }
        public string disburseCurrency { get; set; }
        public string chargeCurrency { get; set; }
        public string flutterChargeResponseMessage { get; set; }
        public string flutterChargeResponseCode { get; set; }
        public string flutterDisburseResponseMessage { get; set; }
        public string flutterChargeReference { get; set; }
        public string flutterDisburseReference { get; set; }
        public string flutterDisburseResponseCode { get; set; }

    }
}
