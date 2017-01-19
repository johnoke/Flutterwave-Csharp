using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flutterwave.DTOs
{
    public class Destination
    {
        public string BankCode { get; set; }
        public string RecipientAccount { get; set; }
        public string RecipientName { get; set; }
        public string Country { get; set; }
        public string Currency { get; set; }
    }
}
