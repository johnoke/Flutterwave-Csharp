using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flutterwave.Moneywave.CommunicationObjects
{
    public class ValidateChargeCardRequest
    {
        public string transactionRef { get; set; }
        public string otp { get; set; }
    }
}
