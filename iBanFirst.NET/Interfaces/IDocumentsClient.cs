using iBanFirst.NET.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iBanFirst.NET.Clients
{
    public interface IDocumentsClient
    {
        Task<iBanFirstApiResponse<Document>> Get(string id);
        Task<iBanFirstApiResponse<Document>> GetRIB();
        Task<iBanFirstApiResponse<List<DocumentList>>> List();
        Task<iBanFirstApiResponse<Document>> Upload(DocumentObject documentObject, DocumentType documentType, DocumentCreate document);
    }
}