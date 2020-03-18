using iBanFirst.NET.Clients;
using iBanFirst.NET.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace iBanFirst.NET.Tests
{
    public class LogsClientTests
    {

        [Fact]
        public async Task CanDeserializeLogsListResponse()
        {
            var client = new iBanFirstClient(new HttpClient(new FakeHttpMessageHandler<List<Log>>()));
            var tx = await client.Logs.List();
            Assert.NotNull(tx);
            Assert.IsType<List<Log>>(tx.Result);
        }

        [Fact]
        public async Task CanDeserializeLogsDetailResponse()
        {
            var client = new iBanFirstClient(new HttpClient(new FakeHttpMessageHandler<Log>()));
            var tx = await client.Logs.Get("account-id");
            Assert.NotNull(tx);
            Assert.IsType<Log>(tx.Result);
        }

    }
}
