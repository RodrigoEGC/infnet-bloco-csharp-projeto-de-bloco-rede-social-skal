using Azure.Storage.Blobs;
using Domain.Model.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class BlobRepository : IBlobRepository
    {
        const string connectionString = @"DefaultEndpointsProtocol=https;AccountName=skal;AccountKey=l0GNO/bTwJ/191NmBCkL5CPBERXT5xwE+5vJfVzwW5EEF8wOL+vAomuD4UQEo084WGhpaCIXYCWZqJVvye+5Jg==;EndpointSuffix=core.windows.net";
        public Uri StoragePost(IFormFile image)
        {
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
            
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient("fotos-posts");

            if (containerClient == null)
                blobServiceClient.CreateBlobContainer("fotos-posts");
            
            BlobClient blobClient = containerClient.GetBlobClient(image.FileName);

            
            blobClient.UploadAsync(image.OpenReadStream());


            //try
            //{
            //    var fotoStream = image.OpenReadStream();

            //    await blobClient.UploadAsync(fotoStream, true);

            //    fotoStream.Close();
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
            return blobClient.Uri;
        }

        public async Task<Uri> StorageProfile(IFormFile image)
        {
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
            
            BlobContainerClient containerClient = await blobServiceClient.CreateBlobContainerAsync("fotos-do-perfil");
            
            BlobClient blobClient = containerClient.GetBlobClient(image.FileName);
            
            var fotoStream = image.OpenReadStream();
            
            await blobClient.UploadAsync(fotoStream, true);

            fotoStream.Close();

            return blobClient.Uri;
        }
    }
}
