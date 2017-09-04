using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flutterwave.Moneywave.CommunicationObjects
{
    public class TokenizeCardRequest
    {
        public string card_no { get; set; }
        public string expiry_year { get; set; }
        public string expiry_month { get; set; }
        public string cvv { get; set; }
    }
}
