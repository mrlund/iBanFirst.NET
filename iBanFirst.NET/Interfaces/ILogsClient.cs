using iBanFirst.NET.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iBanFirst.NET.Interfaces
{
    public interface ILogsClient
    {
        Task<iBanFirstApiResponse<Log>> Get(string nonce);
        Task<iBanFirstApiResponse<List<Log>>> List();
    }
}