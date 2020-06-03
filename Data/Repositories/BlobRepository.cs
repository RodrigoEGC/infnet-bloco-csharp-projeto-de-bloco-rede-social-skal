using Azure.Storage.Blobs;
using Domain.Model.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class BlobRepository : IBlobRepository
    {
        const string connectionString = @"#";
        public Uri StoragePost(IFormFile image)
        {
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
            
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient("fotos-posts");
            
            if (containerClient == null)
                blobServiceClient.CreateBlobContainer("fotos-posts");
            
            BlobClient blobClient = containerClient.GetBlobClient(image.FileName);
            try
            {
                var fotoStream = image.OpenReadStream();
                
                blobClient.UploadAsync(fotoStream, true).Wait();

                fotoStream.Close();
            }
            catch (Exception)
            {
                throw;
            }
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
