using System;
using System.Collections.Generic;
using System.Text;

namespace iBanFirst.NET.Entities
{
    public class WalletDetail
    {
        public string id { get; set; }
        public string currency { get; set; }
        public string tag { get; set; }
        public string status { get; set; }
        public string accountNumber { get; set; }
        public Correspondentbank correspondentBank { get; set; }
        public Holderbank holderBank { get; set; }
        public Holder holder { get; set; }
    }

    public class Correspondentbank
    {
        public string bic { get; set; }
        public string name { get; set; }
        public Address address { get; set; }
    }

    public class Address
    {
        public string street { get; set; }
        public string postCode { get; set; }
        public string city { get; set; }
        public string province { get; set; }
        public string country { get; set; }
    }

    public class Holderbank
    {
        public string bic { get; set; }
        public string clearingCodeType { get; set; }
        public string clearingCode { get; set; }
        public string name { get; set; }
        public Address address { get; set; }
    }

    public class Holder
    {
        public string name { get; set; }
        public string type { get; set; }
        public Address address { get; set; }
    }

}
