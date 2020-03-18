using iBanFirst.NET.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iBanFirst.NET.Interfaces
{
    public interface IPaymentsClient
    {
        Task<iBanFirstApiResponse<Payment>> Confirm(string id);
        Task<iBanFirstApiResponse<Payment>> Create(PaymentCreate payment);
        Task<iBanFirstApiResponse<DeleteResponse>> Delete(string id);
        Task<iBanFirstApiResponse<Payment>> Get(string id);
        Task<iBanFirstApiResponse<PaymentOptionResponse>> GetPaymentOptions(string walletId, string externalBankAccountId);
        Task<iBanFirstApiResponse<List<Payment>>> List(PaymentStatus status);
        Task<iBanFirstApiResponse<Payment>> UploadProofOfTransaction(string id, byte[] file);
    }
}