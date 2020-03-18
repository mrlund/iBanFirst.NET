using System;
using System.Collections.Generic;
using System.Text;

namespace iBanFirst.NET.Entities
{
    public class FinancialMovementList
    {
        public string id { get; set; }
        public string bookingDate { get; set; }
        public string walletId { get; set; }
        public string valueDate { get; set; }
        public Amount amount { get; set; }
    }

    public class FinancialMovement
    {
        public string id { get; set; }
        public string bookingDate { get; set; }
        public string valueDate { get; set; }
        public string orderingAccountNumber { get; set; }
        public string orderingCustomer { get; set; }
        public string orderingInstitution { get; set; }
        public Amount orderingAmount { get; set; }
        public string beneficiaryAccountNumber { get; set; }
        public string beneficiaryCustomer { get; set; }
        public string beneficiaryInstitution { get; set; }
        public Amount beneficiaryAmount { get; set; }
        public string remittanceInformation { get; set; }
        public string chargesDetails { get; set; }
        public int exchangeRate { get; set; }
        public string typeLabel { get; set; }
        public string internalReference { get; set; }
        public string description { get; set; }
    }



}
