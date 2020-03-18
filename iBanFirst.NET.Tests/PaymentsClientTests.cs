using iBanFirst.NET.Clients;
using iBanFirst.NET.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace iBanFirst.NET.Tests
{
    public class PaymentsClientTests
    {

        [Fact]
        public async Task CanDeserializePaymentsListResponse()
        {
            var client = new iBanFirstClient(new HttpClient(new FakeHttpMessageHandler<List<Payment>>()));
            var tx = await client.Payments.List(TransactionStatus.all);
            Assert.NotNull(tx);
            Assert.IsType<List<Payment>>(tx.Result);
        }

        [Fact]
        public async Task CanDeserializePaymentDetailResponse()
        {
            var client = new iBanFirstClient(new HttpClient(new FakeHttpMessageHandler<Payment>()));
            var tx = await client.Payments.Get("account-id");
            Assert.NotNull(tx);
            Assert.IsType<Payment>(tx.Result);
        }

    }
}
