using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Interfaces;
using Common.Interfaces;
using Common.Models;
using Microsoft.AspNetCore.WebUtilities;

namespace Business.Services
{
    public class SearchService : ISearchService
    {
        private readonly ISearchManager _searchManager;

        public SearchService(ISearchManager searchManager)
        {
            _searchManager = searchManager;
        }

        public async Task<List<BlobSearchIndexResponse>> Search(string text)
        {
            throw new NotImplementedException();
        }
    }
}
