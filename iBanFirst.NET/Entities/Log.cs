using System;
using System.Collections.Generic;
using System.Text;

namespace iBanFirst.NET.Entities
{
    public class Log
    {
        public string id { get; set; }
        public string createdAt { get; set; }
        public string closedAt { get; set; }
        public string tokenNonce { get; set; }
        public string remoteAddress { get; set; }
        public string requestMethod { get; set; }
        public string uriRequested { get; set; }
        public string parametersGiven { get; set; }
        public string requestBody { get; set; }
        public int httpResponseCode { get; set; }
        public string responseBody { get; set; }
        public int restErrorTypeId { get; set; }
        public string login { get; set; }
        public string legalname { get; set; }
    }
}
