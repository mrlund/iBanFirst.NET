using iBanFirst.NET.Entities;
using iBanFirst.NET.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iBanFirst.NET.Clients
{
    public class LogsClient : ILogsClient
    {
        private readonly iBanFirstClientBase _client;

        public LogsClient(iBanFirstClientBase client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }
        public async Task<iBanFirstApiResponse<List<Log>>> List()
        {
            return await _client.MakeApiRequest<List<Log>>("logs/");
        }
        public async Task<iBanFirstApiResponse<Log>> Get(string nonce)
        {
            return await _client.MakeApiRequest<Log>($"logs/{nonce}");
        }
    }

}
