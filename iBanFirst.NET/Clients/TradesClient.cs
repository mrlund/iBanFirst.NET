using iBanFirst.NET.Entities;
using iBanFirst.NET.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iBanFirst.NET.Clients
{
    public class TradesClient : ITradesClient
    {
        private readonly iBanFirstClientBase _client;

        public TradesClient(iBanFirstClientBase client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }


        public async Task<iBanFirstApiResponse<List<Rate>>> RetrieveRates(string instruments)
        {
            return await _client.MakeApiRequest<List<Rate>>($"rates/{instruments}/");
        }
        public async Task<iBanFirstApiResponse<Trade>> CreateQuote(TradeCreate trade)
        {
            return await _client.MakeApiRequest<Trade>("quotes/", Utilities.RequestMethod.POST, trade);
        }
        public async Task<iBanFirstApiResponse<Trade>> ExecuteTrade(TradeCreate trade)
        {
            return await _client.MakeApiRequest<Trade>("trades/", Utilities.RequestMethod.POST, trade);
        }
        public async Task<iBanFirstApiResponse<List<Trade>>> List(TransactionStatus status)
        {
            return await _client.MakeApiRequest<List<Trade>>($"trades/{Enum.GetName(typeof(TransactionStatus), status)}/");
        }

        public async Task<iBanFirstApiResponse<Trade>> Get(string id)
        {
            return await _client.MakeApiRequest<Trade>($"trades/-{id}");
        }

    }
}
