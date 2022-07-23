using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Models;

namespace Business.Interfaces
{
    public interface ISearchService
    {
        Task<List<BlobSearchIndexResponse>> SearchAsync(string text);
    }
}
