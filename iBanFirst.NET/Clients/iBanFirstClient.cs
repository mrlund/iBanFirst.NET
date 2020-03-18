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
        //This setup may seem a little verbose, but its purpose is to provide a nice intuitive API for users. 
        //For example, just having one client object, and still separating the API areas nicely like 
        // _client.Payments.List(); _client.Wallets.Get("id"); etc. 

        private readonly IWalletsClient _walletsClient;
        private readonly IFinancialMovementsClient _financialMovementsClient;
        private readonly IExternalBankAccountsClient _externalBankAccountsClient;
        private readonly IPaymentsClient _paymentsClient ;
        private readonly ITradesClient _tradesClient;
        private readonly IDocumentsClient _documentsClient;
        private readonly ILogsClient _logsClient;

        public IWalletsClient Wallets => _walletsClient;
        public IFinancialMovementsClient FinancialMovements => _financialMovementsClient;
        public IExternalBankAccountsClient ExternalBankAccounts => _externalBankAccountsClient;
        public IPaymentsClient Payments => _paymentsClient;
        public ITradesClient Trades => _tradesClient;
        public IDocumentsClient Documents => _documentsClient;
        public ILogsClient Logs => _logsClient;

        public iBanFirstClient(HttpClient httpClient, 
                                string userName = null, 
                                string clientSecret = null, 
                                ILoggerFactory loggerFactory = null,
                                TargetEnvironment environment = TargetEnvironment.SANDBOX) 
                                    : base(httpClient, userName, clientSecret, loggerFactory)
        {
            SetBaseUri(environment == TargetEnvironment.PRODUCTION ? iBanFirstUrls.PRODUCTION : iBanFirstUrls.SANDBOX );

            _walletsClient = new WalletsClient(this);
            _financialMovementsClient = new FinancialMovementsClient(this);
            _externalBankAccountsClient = new ExternalBankAccountsClient(this);
            _paymentsClient = new PaymentsClient(this);
            _tradesClient = new TradesClient(this);
            _documentsClient = new DocumentsClient(this);
            _logsClient = new LogsClient(this);

        }

    }
}
