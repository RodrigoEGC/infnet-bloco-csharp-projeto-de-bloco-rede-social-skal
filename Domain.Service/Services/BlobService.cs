using Domain.Model.Interfaces.Repositories;
using Domain.Model.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.Services
{
    public class BlobService : IBlobService
    {
        private readonly IBlobRepository _blobRepository;

        public BlobService(IBlobRepository blobRepository)
        {
            _blobRepository = blobRepository;
        }
        public  Uri StoragePost(IFormFile image)
        {
            return  _blobRepository.StoragePost(image);
        }

        public async Task<Uri> StorageProfile(IFormFile image)
        {
            return await _blobRepository.StorageProfile(image);
        }
    }
}
