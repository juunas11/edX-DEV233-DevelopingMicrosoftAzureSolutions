using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using System.Configuration;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.IO;

namespace Contoso.Events.Worker
{
    internal class BlobStorageManager
    {
        protected readonly CloudBlobClient _blobClient;

        public BlobStorageManager()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["Microsoft.WindowsAzure.Storage.ConnectionString"].ConnectionString);
            _blobClient = storageAccount.CreateCloudBlobClient();
        }

        public Uri CreateBlob(MemoryStream stream, string eventKey)
        {
            CloudBlobContainer container = _blobClient.GetContainerReference("signin");
            container.CreateIfNotExists();

            string blobName = String.Format("{0}_SignIn_{1:ddmmyyyss}.docx", eventKey, DateTime.UtcNow);

            ICloudBlob blob = container.GetBlockBlobReference(blobName);
            stream.Seek(0, SeekOrigin.Begin);
            blob.UploadFromStream(stream);

            return blob.Uri;
        }
    }
}