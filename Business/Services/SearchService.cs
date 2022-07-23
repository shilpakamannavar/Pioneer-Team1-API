using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Interfaces;
using Common.Interfaces;
using Business.Models;
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
        
        public async Task<List<BlobSearchIndexResponse>> SearchAsync(string text)
        {
            var searchResponse = new List<BlobSearchIndexResponse>();
            var searchResults = await _searchManager.SearchAsync(text);
            foreach (var res in searchResults)
            {
                searchResponse.Add(new BlobSearchIndexResponse
                {
                    Content = res.Document.BlobContent,
                    FileURI = this.Decrypt(res.Document.EncryptedBlobURI)
                });
            }

            return searchResponse;
        }

        private string Decrypt(string encryptedText)
        {
            byte[] bytes = WebEncoders.Base64UrlDecode(encryptedText);
            return System.Text.Encoding.Default.GetString(bytes);
        }
    }
}
