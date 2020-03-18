using iBanFirst.NET.Clients;
using iBanFirst.NET.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace iBanFirst.NET.Tests
{
    public class ExternalBankAccountClientTests
    {

        [Fact]
        public async Task CanDeserializeExternalBankAccountListResponse()
        {
            var client = new iBanFirstClient(new HttpClient(new FakeHttpMessageHandler<List<ExternalBankAccount>>()));
            var tx = await client.ExternalBankAccounts.List();
            Assert.NotNull(tx);
            Assert.IsType<List<ExternalBankAccount>>(tx.Result);
        }

        [Fact]
        public async Task CanDeserializeExternalBankAccountDetailResponse()
        {
            var client = new iBanFirstClient(new HttpClient(new FakeHttpMessageHandler<ExternalBankAccount>()));
            var tx = await client.ExternalBankAccounts.Get("account-id");
            Assert.NotNull(tx);
            Assert.IsType<ExternalBankAccount>(tx.Result);
        }

    }
}
