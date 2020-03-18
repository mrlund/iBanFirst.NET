using System;
using System.Collections.Generic;
using System.Text;

namespace iBanFirst.NET.Entities
{
    public class Trade
    {
        public string id { get; set; }
        public string appliedRate { get; set; }
        public string currencyPair { get; set; }
        public Amount sourceAmount { get; set; }
        public Amount deliveredAmount { get; set; }
        public string createdDate { get; set; }
        public string deliveryDate { get; set; }
        public string tag { get; set; }
    }


    public class TradeCreate
    {
        public string currencyPair { get; set; }
        public string side { get; set; }
        public Amount amount { get; set; }
        public string deliveryDate { get; set; }
        public string sourceWalletId { get; set; }
        public string deliveryWalletId { get; set; }
        public string tag { get; set; }
    }

}
