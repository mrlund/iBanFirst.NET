using iBanFirst.NET.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iBanFirst.NET.Interfaces
{
    public interface IWalletsClient
    {
        Task<iBanFirstApiResponse<WalletBalance>> Balance(string walletId, DateTime date);
        Task<iBanFirstApiResponse<WalletDetail>> Create(WalletCreate wallet);
        Task<iBanFirstApiResponse<WalletDetail>> Get(string walletId);
        Task<iBanFirstApiResponse<List<WalletList>>> List();
    }
}