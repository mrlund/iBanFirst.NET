using System;
using System.Collections.Generic;
using System.Text;

namespace iBanFirst.NET.Entities
{
    public class WalletList
    {
        public string id { get; set; }
        public string tag { get; set; }
        public string currency { get; set; }
        public Amount bookingAmount { get; set; }
        public Amount valueAmount { get; set; }
        public DateTime dateLastFinancialMovement { get; set; }
    }

    public class WalletBalance
    {
        public string id { get; set; }
        public Balance balance { get; set; }
    }

    public class Balance
    {
        public string closingDate { get; set; }
        public Amount bookingAmount { get; set; }
        public Amount valueAmount { get; set; }
    }


    public class Amount
    {
        public decimal value { get; set; }
        public string currency { get; set; }
    }

}
