using iBanFirst.NET.Entities;
using iBanFirst.NET.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iBanFirst.NET.Clients
{
    public class FinancialMovementsClient : IFinancialMovementsClient
    {
        private readonly iBanFirstClientBase _client;

        public FinancialMovementsClient(iBanFirstClientBase client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<iBanFirstApiResponse<List<FinancialMovementList>>> List()
        {
            return await _client.MakeApiRequest<List<FinancialMovementList>>("financialMovements");
        }
        public async Task<iBanFirstApiResponse<FinancialMovement>> Get(string id)
        {
            return await _client.MakeApiRequest<FinancialMovement>($"financialMovements/{id}");
        }


    }
}
