using iBanFirst.NET.Clients;
using iBanFirst.NET.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace iBanFirst.NET.Tests
{
    public class TradesClientTests
    {

        [Fact]
        public async Task CanDeserializeTradesListResponse()
        {
            var client = new iBanFirstClient(new HttpClient(new FakeHttpMessageHandler<List<Trade>>()));
            var tx = await client.Trades.List(TransactionStatus.all);
            Assert.NotNull(tx);
            Assert.IsType<List<Trade>>(tx.Result);
        }

        [Fact]
        public async Task CanDeserializePaymentDetailResponse()
        {
            var client = new iBanFirstClient(new HttpClient(new FakeHttpMessageHandler<Trade>()));
            var tx = await client.Trades.Get("account-id");
            Assert.NotNull(tx);
            Assert.IsType<Trade>(tx.Result);
        }

    }
}
