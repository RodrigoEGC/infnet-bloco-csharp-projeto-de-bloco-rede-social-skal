using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Domain.Model.Interfaces.Services
{
    public interface IBlobService
    {
        Task<Uri> StorageProfile(IFormFile image);
        Uri StoragePost(IFormFile image);
    }
}
