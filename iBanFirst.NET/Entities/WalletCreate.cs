using System;
using System.Collections.Generic;
using System.Text;

namespace iBanFirst.NET.Entities
{
    public class WalletCreate
    {
        public string currency { get; set; }
        public string tag { get; set; }
        public Holder holder { get; set; }
    }

}
