using System;
using System.IO;
using Azure.Storage.Blobs;
using Common.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Common.Utilities
{
    public class AzureBlobStoaregManager : IBlobStorageManager
    {
        private readonly BlobContainerClient container;
        public AzureBlobStoaregManager(IConfiguration config)
        {
            container = new BlobContainerClient(config.GetConnectionString("AzureStorage"), config.GetSection("ContainerName").Value);
            container.Create();
        }

        public void Add(Stream content)
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public string GetDownload(string blobName)
        {
            var blobClient = container.GetBlobClient(blobName);
            return blobClient.Uri.AbsoluteUri;
        }
    }
}
