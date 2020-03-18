# iBanFirst.NET

Community contributed NETStandard 2.0 client for the iBanFirst API

This plugin is *not* developed or maintained by iBanFirst but kindly made
available by the community.

Released under the MIT license: https://opensource.org/licenses/MIT

**Installation**
`nuget install iBanFirst.NET`
-or-
`dotnet add package iBanFirst.NET`

**iBanFirstClient**
```c#
var client = new iBanFirstClient(HttpClient httpClient, string userName = null, string clientSecret = null, ILoggerFactory logger = null)
```


Generally the client follows the iBanFirst API docs in use to make it as intuitive as possible. Consider the  
[iBanFirst API](https://platform.ibanfirst.com/APIDocumentation/IbanfirstAPI/Endpoints/#!/Wallets/get_wallets) API docs, and compare with the examples below:

Examples:
```c#
var client = new iBanFirstClient(httpClient, "username", "secret"); 
```
```c#
var wallets = await client.Wallets.List(); 
```
```c#
var wallet = await client.Wallets.Get("wallet-id"); 
```
```c#
var externalBankAccount = await client.ExternalBankAccounts.List(); 
```
```c#
var payments = await client.Payments.List(PaymentStatus.all); 
```
```c#
var payment = await client.Payments.Create(payment); 
```


# Available services

**Wallets**

* Task<iBanFirstApiResponse<WalletBalance\>> Balance(string walletId, DateTime date);
* Task<iBanFirstApiResponse<WalletDetail\>> Create(WalletCreate wallet);
* Task<iBanFirstApiResponse<WalletDetail\>> Get(string walletId);
* Task<iBanFirstApiResponse<List<WalletList\>\>> List();

**Financial Movements**
* Task<iBanFirstApiResponse<FinancialMovement>> Get(string id);
* Task<iBanFirstApiResponse<List<FinancialMovementList>>> List();

**External Bank Accounts**
* Task<iBanFirstApiResponse<ExternalBankAccount\>> Create(ExternalBankAccount externalBankAccount);
* Task<iBanFirstApiResponse<DeleteResponse\>> Delete(string id);
* Task<iBanFirstApiResponse<ExternalBankAccount\>> Get(string id);
* Task<iBanFirstApiResponse<List<ExternalBankAccount\>\>> List();

**Payments**
* Task<iBanFirstApiResponse<Payment\>> Confirm(string id);
* Task<iBanFirstApiResponse<Payment\>> Create(PaymentCreate payment);
* Task<iBanFirstApiResponse<DeleteResponse\>> Delete(string id);
* Task<iBanFirstApiResponse<Payment\>> Get(string id);
* Task<iBanFirstApiResponse<PaymentOptionResponse\>> GetPaymentOptions(string walletId, string externalBankAccountId);
* Task<iBanFirstApiResponse<List<Payment\>\>> List(PaymentStatus status);
* Task<iBanFirstApiResponse<Payment\>> UploadProofOfTransaction(string id, byte[] file);

**Trades**
* Task<iBanFirstApiResponse<Trade\>> CreateQuote(TradeCreate trade);
* Task<iBanFirstApiResponse<Trade\>> ExecuteTrade(TradeCreate trade);
* Task<iBanFirstApiResponse<Trade\>> Get(string id);
* Task<iBanFirstApiResponse<List<Trade\>\>> List(TransactionStatus status);
* Task<iBanFirstApiResponse<List<Rate\>\>> RetrieveRates(string instruments);

**Documents**
* Task<iBanFirstApiResponse<Document\>> Get(string id);
* Task<iBanFirstApiResponse<Document\>> GetRIB();
* Task<iBanFirstApiResponse<List<DocumentList\>\>> List();
* Task<iBanFirstApiResponse<Document\>> Upload(DocumentObject documentObject, DocumentType documentType, DocumentCreate document);

**Logs**
* Task<iBanFirstApiResponse<Log\>> Get(string nonce);
* Task<iBanFirstApiResponse<List<Log\>\>> List();