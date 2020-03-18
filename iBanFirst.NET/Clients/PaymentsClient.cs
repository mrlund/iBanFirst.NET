using iBanFirst.NET.Entities;
using iBanFirst.NET.Interfaces;
using iBanFirst.NET.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iBanFirst.NET.Clients
{
    public class PaymentsClient : IPaymentsClient
    {
        private readonly iBanFirstClientBase _client;

        public PaymentsClient(iBanFirstClientBase client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<iBanFirstApiResponse<List<Payment>>> List(PaymentStatus status)
        {
            return await _client.MakeApiRequest<List<Payment>>($"payments/{Enum.GetName(typeof(PaymentStatus), status)}");
        }
        public async Task<iBanFirstApiResponse<Payment>> Get(string id)
        {
            return await _client.MakeApiRequest<Payment>($"payments/{id}");
        }
        public async Task<iBanFirstApiResponse<Payment>> Create(PaymentCreate payment)
        {
            return await _client.MakeApiRequest<Payment>("payments", RequestMethod.POST, payment);
        }
        public async Task<iBanFirstApiResponse<Payment>> Confirm(string id)
        {
            return await _client.MakeApiRequest<Payment>($"payments/{id}/confirm", RequestMethod.PUT);
        }
        public async Task<iBanFirstApiResponse<PaymentOptionResponse>> GetPaymentOptions(string walletId, string externalBankAccountId)
        {
            return await _client.MakeApiRequest<PaymentOptionResponse>($"payments/options/{walletId}/{externalBankAccountId}");
        }
        public async Task<iBanFirstApiResponse<Payment>> UploadProofOfTransaction(string id, byte[] file)
        {
            throw new NotImplementedException();
            //return await _client.MakeApiRequest<Payment>($"payments/{id}/proofOfTransaction", RequestMethod.PUT);
        }

        public async Task<iBanFirstApiResponse<DeleteResponse>> Delete(string id)
        {
            return await _client.MakeApiRequest<DeleteResponse>($"payments/{id}", RequestMethod.DELETE);
        }

    }
}
