using iBanFirst.NET.Clients;
using iBanFirst.NET.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace iBanFirst.NET.Tests
{
    public class WalletsClientTests
    {
        [Fact]
        public void CanInstantiateClient()
        {
            var client = new iBanFirstClient(new HttpClient());
            Assert.NotNull(client);

        }

        [Fact]
        public async Task CanDeserializeWalletListResponse()
        {
            var client = new iBanFirstClient(new HttpClient(new FakeHttpMessageHandler<List<WalletList>>()));
            var tx = await client.Wallets.List();
            Assert.NotNull(tx);
            Assert.IsType<List<WalletList>>(tx.Result);
        }

        [Fact]
        public async Task CanDeserializeWalletDetailResponse()
        {
            var client = new iBanFirstClient(new HttpClient(new FakeHttpMessageHandler<WalletDetail>()));
            var tx = await client.Wallets.Get("wallet-id");
            Assert.NotNull(tx);
            Assert.IsType<WalletDetail>(tx.Result);
        }

        [Fact]
        public async Task CanMakeTwoRequestsFromSameClientInstance()
        {
            var client = new iBanFirstClient(new HttpClient(new FakeHttpMessageHandler<WalletDetail>()));
            var tx = await client.Wallets.Get("wallet-id");
            Assert.NotNull(tx);
            Assert.IsType<WalletDetail>(tx.Result);

            var tx2 = await client.Wallets.Get("wallet-id");
            Assert.NotNull(tx2);
            Assert.IsType<WalletDetail>(tx2.Result);

        }
    }
}
