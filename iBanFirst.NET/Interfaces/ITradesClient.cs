using iBanFirst.NET.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iBanFirst.NET.Interfaces
{
    public interface ITradesClient
    {
        Task<iBanFirstApiResponse<Trade>> CreateQuote(TradeCreate trade);
        Task<iBanFirstApiResponse<Trade>> ExecuteTrade(TradeCreate trade);
        Task<iBanFirstApiResponse<Trade>> Get(string id);
        Task<iBanFirstApiResponse<List<Trade>>> List(TransactionStatus status);
        Task<iBanFirstApiResponse<List<Rate>>> RetrieveRates(string instruments);
    }
}