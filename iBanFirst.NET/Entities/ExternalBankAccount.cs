using System;
using System.Collections.Generic;
using System.Text;

namespace iBanFirst.NET.Entities
{
    public class ExternalBankAccount
    {
        public string id { get; set; }
        public string currency { get; set; }
        public string tag { get; set; }
        public string accountNumber { get; set; }
        public Correspondentbank correspondentBank { get; set; }
        public Holderbank holderBank { get; set; }
        public Holder holder { get; set; }
        public string correspondentBic { get; set; }
    }

}
