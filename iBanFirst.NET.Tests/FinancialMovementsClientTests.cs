using iBanFirst.NET.Clients;
using iBanFirst.NET.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Xunit;

namespace iBanFirst.NET.Tests
{
    public class FinancialMovementsClientTests
    {

        [Fact]
        public async Task CanDeserializeFinancialMovementsResponse()
        {
            var client = new iBanFirstClient(new HttpClient(new FakeHttpMessageHandler<List<FinancialMovementList>>()));
            var tx = await client.FinancialMovements.List();
            Assert.NotNull(tx);
            Assert.IsType<List<FinancialMovementList>>(tx.Result);
        }

        [Fact]
        public async Task CanDeserializeFinancialMovementsDetailResponse()
        {
            var client = new iBanFirstClient(new HttpClient(new FakeHttpMessageHandler<FinancialMovement>()));
            var tx = await client.FinancialMovements.Get("account-id");
            Assert.NotNull(tx);
            Assert.IsType<FinancialMovement>(tx.Result);
        }

    }
}
