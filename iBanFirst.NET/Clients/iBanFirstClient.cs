using iBanFirst.NET.Entities;
using iBanFirst.NET.Interfaces;
using iBanFirst.NET.Utilities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace iBanFirst.NET.Clients
{
    public class iBanFirstClient : iBanFirstClientBase
    {
        private readonly IWalletsClient _walletsClient;
        private readonly IPaymentsClient _paymentsClient ;
        private readonly IExternalBankAccountsClient _externalBankAccountsClient;

        public IWalletsClient Wallets => _walletsClient;
        public IPaymentsClient Payments => _paymentsClient;
        public IExternalBankAccountsClient ExternalBankAccounts => _externalBankAccountsClient;

        public iBanFirstClient(HttpClient httpClient, 
                                string userName = null, 
                                string clientSecret = null, 
                                ILoggerFactory loggerFactory = null,
                                TargetEnvironment environment = TargetEnvironment.SANDBOX) 
                                    : base(httpClient, userName, clientSecret, loggerFactory)
        {
            SetBaseUri(environment == TargetEnvironment.PRODUCTION ? iBanFirstUrls.PRODUCTION : iBanFirstUrls.SANDBOX );

            _walletsClient = new WalletsClient(this);
            _externalBankAccountsClient = new ExternalBankAccountsClient(this);
            _paymentsClient = new PaymentsClient(this);

        }

    }
}
