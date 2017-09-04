using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flutterwave.Moneywave.OperationObjects
{
    public class CardOperation
    {
        public string ChargeCard { get; set; }
        public string ValidateCharge { get; set; }
        public string TransactionStatus { get; set; }
        public string Tokenize { get; set; }
        public string CardToWallet { get; set; }
    }
}
