using iBanFirst.NET.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iBanFirst.NET.Clients
{
    public class DocumentsClient : IDocumentsClient
    {
        private readonly iBanFirstClientBase _client;

        public DocumentsClient(iBanFirstClientBase client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }
        public async Task<iBanFirstApiResponse<List<DocumentList>>> List()
        {
            return await _client.MakeApiRequest<List<DocumentList>>("documents/");
        }
        public async Task<iBanFirstApiResponse<Document>> Get(string id)
        {
            return await _client.MakeApiRequest<Document>($"documents/{id}");
        }

        public async Task<iBanFirstApiResponse<Document>> GetRIB()
        {
            return await _client.MakeApiRequest<Document>("documents/RIB");
        }
        public async Task<iBanFirstApiResponse<Document>> Upload(DocumentObject documentObject, DocumentType documentType, DocumentCreate document)
        {
            return await _client.MakeApiRequest<Document>($"documents/upload/{Enum.GetName(typeof(DocumentObject), documentObject)}/{Enum.GetName(typeof(DocumentType), documentType)}", Utilities.RequestMethod.POST, document);
        }
    }
}
