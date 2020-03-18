using System;
using System.Collections.Generic;
using System.Text;

namespace iBanFirst.NET.Entities
{
    public class Document
    {
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string createdDate { get; set; }
        public string lastOpennedDate { get; set; }
        public string mimeType { get; set; }
        public string link { get; set; }
    }

    public class DocumentList
    {
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string createdDate { get; set; }
        public string link { get; set; }
    }
    public class DocumentCreate
    {
        public string tag { get; set; }
        public string file { get; set; }
    }

    public enum DocumentObject
    {
        externalBankAccount,
        payment
    }
    public enum DocumentType
    {
        identity,
        invoice
    }
}
