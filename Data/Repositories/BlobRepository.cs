using Azure.Storage.Blobs;
using Domain.Model.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class BlobRepository : IBlobRepository
    {
        const string connectionString = @"DefaultEndpointsProtocol=https;AccountName=projetodebloco;AccountKey=eUCh23HER3DszpCKj1Q0OyPFTWKucuAx0mHY3VkYW3ApFZ7IU+m1r2GT1nI4PdL20x7mJ1lD4l7MVxOv2Zna7A==;EndpointSuffix=core.windows.net";
        public async Task<Uri> StoragePost(IFormFile image)
        {
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
            
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient("fotos-posts");
            
            if (containerClient == null)
                blobServiceClient.CreateBlobContainer("fotos-posts");
            
            BlobClient blobClient = containerClient.GetBlobClient(image.FileName);
            try
            {
                var fotoStream = image.OpenReadStream();

                await blobClient.UploadAsync(fotoStream, true);

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
