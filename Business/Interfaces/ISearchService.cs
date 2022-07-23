using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ISearchService
    {
        Task<List<BlobSearchIndexResponse>> SearchAsync(string text);
    }
}
