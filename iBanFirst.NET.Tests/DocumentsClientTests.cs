using iBanFirst.NET.Clients;
using iBanFirst.NET.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace iBanFirst.NET.Tests
{
    public class DocumentsClientTests
    {

        [Fact]
        public async Task CanDeserializeDocumentListResponse()
        {
            var client = new iBanFirstClient(new HttpClient(new FakeHttpMessageHandler<List<DocumentList>>()));
            var tx = await client.Documents.List();
            Assert.NotNull(tx);
            Assert.IsType<List<DocumentList>>(tx.Result);
        }

        [Fact]
        public async Task CanDeserializeDocumentDetailResponse()
        {
            var client = new iBanFirstClient(new HttpClient(new FakeHttpMessageHandler<Document>()));
            var tx = await client.Documents.Get("account-id");
            Assert.NotNull(tx);
            Assert.IsType<Document>(tx.Result);
        }

    }
}
