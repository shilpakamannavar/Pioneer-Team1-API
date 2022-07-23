using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Common.Interfaces
{
    public interface IBlobStorageManager
    {
        void Add(Stream content);

        string GetDownload(string blobName);

        void Delete();
    }
}
