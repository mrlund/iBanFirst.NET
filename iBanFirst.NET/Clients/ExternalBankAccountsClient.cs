using iBanFirst.NET.Entities;
using iBanFirst.NET.Interfaces;
using iBanFirst.NET.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iBanFirst.NET.Clients
{
    public class ExternalBankAccountsClient : IExternalBankAccountsClient
    {
        private readonly iBanFirstClientBase _client;

        public ExternalBankAccountsClient(iBanFirstClientBase client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<iBanFirstApiResponse<List<ExternalBankAccount>>> List()
        {
            return await _client.MakeApiRequest<List<ExternalBankAccount>>("externalBankAccounts/");
        }
        public async Task<iBanFirstApiResponse<ExternalBankAccount>> Get(string id)
        {
            return await _client.MakeApiRequest<ExternalBankAccount>($"externalBankAccounts/-{id}");
        }
        public async Task<iBanFirstApiResponse<ExternalBankAccount>> Create(ExternalBankAccount externalBankAccount)
        {
            return await _client.MakeApiRequest<ExternalBankAccount>("externalBankAccounts/", RequestMethod.POST, externalBankAccount);
        }

        public async Task<iBanFirstApiResponse<DeleteResponse>> Delete(string id)
        {
            return await _client.MakeApiRequest<DeleteResponse>($"externalBankAccounts/-{id}", RequestMethod.DELETE);
        }

    }
}
