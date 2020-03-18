using iBanFirst.NET.Entities;
using iBanFirst.NET.Interfaces;
using iBanFirst.NET.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iBanFirst.NET.Clients
{
    public class WalletsClient : IWalletsClient
    {
        private readonly iBanFirstClientBase _client;

        public WalletsClient(iBanFirstClientBase client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<iBanFirstApiResponse<List<WalletList>>> List()
        {
            return await _client.MakeApiRequest<List<WalletList>>("wallets");
        }
        public async Task<iBanFirstApiResponse<WalletDetail>> Get(string walletId)
        {
            return await _client.MakeApiRequest<WalletDetail>($"wallets/{walletId}");
        }
        public async Task<iBanFirstApiResponse<WalletDetail>> Create(WalletCreate wallet)
        {
            return await _client.MakeApiRequest<WalletDetail>("wallets", RequestMethod.POST, wallet);
        }
        public async Task<iBanFirstApiResponse<WalletBalance>> Balance(string walletId, DateTime date)
        {
            return await _client.MakeApiRequest<WalletBalance>($"wallets/{walletId}/balance/{date:yyyy-MM-dd}");
        }
    }
}
