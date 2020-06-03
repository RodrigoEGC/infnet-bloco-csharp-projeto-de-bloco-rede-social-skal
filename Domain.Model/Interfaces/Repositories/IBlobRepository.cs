using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Domain.Model.Interfaces.Repositories
{
    public interface IBlobRepository
    {
        Task<Uri> StorageProfile(IFormFile image);
        Uri StoragePost(IFormFile image);
    }
}
