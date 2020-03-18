using iBanFirst.NET.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iBanFirst.NET.Interfaces
{
    public interface IExternalBankAccountsClient
    {
        Task<iBanFirstApiResponse<ExternalBankAccount>> Create(ExternalBankAccount externalBankAccount);
        Task<iBanFirstApiResponse<DeleteResponse>> Delete(string id);
        Task<iBanFirstApiResponse<ExternalBankAccount>> Get(string id);
        Task<iBanFirstApiResponse<List<ExternalBankAccount>>> List();
    }
}