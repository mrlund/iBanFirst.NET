using iBanFirst.NET.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iBanFirst.NET.Interfaces
{
    public interface IFinancialMovementsClient
    {
        Task<iBanFirstApiResponse<FinancialMovement>> Get(string id);
        Task<iBanFirstApiResponse<List<FinancialMovementList>>> List();
    }
}