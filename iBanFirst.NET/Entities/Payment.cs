using System;
using System.Collections.Generic;
using System.Text;

namespace iBanFirst.NET.Entities
{
    public class Payment
    {
        public string id { get; set; }
        public string status { get; set; }
        public string createdDate { get; set; }
        public string desiredExecutionDate { get; set; }
        public string executionDate { get; set; }
        public Amount amount { get; set; }
        public Amount counterValue { get; set; }
        public Rate rate { get; set; }
        public string tag { get; set; }
        public string externalBankAccountId { get; set; }
        public string sourceWalletId { get; set; }
        public string communication { get; set; }
        public string priorityPaymentOption { get; set; }
        public string feePaymentOption { get; set; }
        public Amount feePaymentAmount { get; set; }
    }

    public class Rate
    {
        public string currencyPair { get; set; }
        public string midMarket { get; set; }
        public string date { get; set; }
        public string coreAsk { get; set; }
        public string coreBid { get; set; }
        public string appliedAsk { get; set; }
        public string appliedBid { get; set; }
    }

    public class PaymentOptionResponse
    {
        public Paymentoption paymentOption { get; set; }
    }

    public class Paymentoption
    {
        public string externalBankAccountId { get; set; }
        public string sourceWalletId { get; set; }
        public Option[] options { get; set; }
    }

    public class Option
    {
        public string priorityPaymentOption { get; set; }
        public string feePaymentOption { get; set; }
        public Amount priorityCost { get; set; }
        public Amount feeCost { get; set; }
        public Amount minimumAmountSource { get; set; }
        public Amount minimumAmountTarget { get; set; }
    }


    public enum PaymentStatus
    {
        all,
        planified,
        rejected,
        finalized,
        cancelled,
        refused,
        blocked,
        waitingconfirmation
    }
}
