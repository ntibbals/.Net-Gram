using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.Gram.Models.Utilities
{
    public class Blob
    {
        public CloudStorageAccount CloudStorageAccount { get; set; }

        public CloudBlobClient CloudBlobClient { get; set; }

        public Blob(IConfiguration configuration)
        {
            CloudStorageAccount = CloudStorageAccount.Parse(configuration["ConnectionStrings:BlobConnectionString"]);
            CloudBlobClient = CloudStorageAccount.CreateCloudBlobClient();
        }

        /// <summary>
        /// Retreive blob container from azure
        /// </summary>
        /// <param name="containerName">name of container</param>
        /// <returns>Container</returns>
        public async Task<CloudBlobContainer> GetContainer(string containerName)
        {
            CloudBlobContainer cbc = CloudBlobClient.GetContainerReference(containerName);
            await cbc.CreateIfNotExistsAsync();
            await cbc.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });

            return cbc;
        }

        /// <summary>
        /// Get blob storage
        /// </summary>
        /// <param name="imageName">name of image to retrive</param>
        /// <param name="containerName">name of container</param>
        /// <returns>object</returns>
        public async Task<CloudBlob> GetBlob(string imageName, string containerName)
        {
            CloudBlobContainer container = await GetContainer(containerName);

            CloudBlob blob = container.GetBlobReference(imageName);

            return blob;
        }

        /// <summary>
        /// Upload a file into blob storage
        /// </summary>
        /// <param name="fileName">file name</param>
        /// <param name="filePath">file path</param>
        /// <param name="cloudBlobContainer">container name</param>
        public void UploadFile(string fileName, string filePath, CloudBlobContainer cloudBlobContainer)
        {
            var blobFile = cloudBlobContainer.GetBlockBlobReference(fileName);
            blobFile.UploadFromFileAsync(filePath);
        }
    }
}
