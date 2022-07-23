using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Search.Documents.Models;
using Common.Models;

namespace Common.Interfaces
{
    public interface ISearchManager
    {
        Task<List<SearchResult<BlobSearchIndexResponse>>> SearchAsync(string text);
    }
}
