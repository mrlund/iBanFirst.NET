using System;
using System.Collections.Generic;
using System.Text;

namespace iBanFirst.NET.Entities
{
    public class PaymentCreate
    {
        public string sourceWalletId { get; set; }
        public string externalBankAccountId { get; set; }
        public Amount amount { get; set; }
        public string desiredExecutionDate { get; set; }
        public string feeCurrency { get; set; }
        public string feePaymentOption { get; set; }
        public string priorityPaymentOption { get; set; }
        public string tag { get; set; }
        public string communication { get; set; }
    }


}
