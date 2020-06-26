using Domain.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Model.Interfaces.Services
{
    public interface IPostService
    {
        Task Send(PostEntity postEntity);
        Task<IEnumerable<PostEntity>> GetAllAsync();
        Task<PostEntity> GetByIdAsync(int id);
        Task UpdateAsync(PostEntity updatedEntity);
        Task DeleteAsync(int id);
    }
}
