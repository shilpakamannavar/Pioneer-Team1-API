using System.Text.Json.Serialization;

namespace Common.Models
{
    public class BlobSearchIndexResponse
    {
        [JsonPropertyName("content")]
        public string BlobContent { get; set; }

        [JsonPropertyName("metadata_storage_path")]
        public string EncryptedBlobURI { get; set; }
    }
}
