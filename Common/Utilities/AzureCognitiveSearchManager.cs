using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Azure.Search.Documents;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Models;
using Common.Interfaces;
using Common.Models;
using Microsoft.Extensions.Configuration;

namespace Common.Utilities
{
    public class AzureCognitiveSearchManager : ISearchManager
    {
        private readonly SearchClient _searchClient;
        public AzureCognitiveSearchManager(IConfiguration config)
        {
            SearchIndexClient indexClient = new SearchIndexClient(new Uri(config.GetSection("SearchServiceUri").Value), new AzureKeyCredential(config.GetSection("SearchServiceQueryApiKey").Value));
            _searchClient = indexClient.GetSearchClient(config.GetSection("SearchIndexName").Value);
        }

        public async Task<List<SearchResult<BlobSearchIndexResponse>>> SearchAsync(string text)
        {
            var options = new SearchOptions()
            {
                IncludeTotalCount = true
            };

            options.Select.Add(text);
            var searchResults = (await _searchClient.SearchAsync<BlobSearchIndexResponse>(text, options).ConfigureAwait(false));
            return searchResults.Value.GetResults().ToList();
        }
    }
}
