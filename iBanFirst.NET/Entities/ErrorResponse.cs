using System;
using System.Collections.Generic;
using System.Text;

namespace iBanFirst.NET.Entities
{
    public class ErrorResponse
    {
        public string ErrorMessage { get; set; }
        public string ErrorType { get; set; }
        public string Link { get; set; }
        public int ErrorCode { get; set; }

    }
}
