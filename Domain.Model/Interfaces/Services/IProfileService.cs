using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Model.Interfaces.Services
{
    public interface IProfileService
    {
        Task<IEnumerable<ProfileEntity>> GetAllAsync();
        Task<ProfileEntity> GetByIdAsync(int id);
        Task InsertAsync(ProfileEntity insertedEntity);
        Task UpdateAsync(ProfileEntity updatedEntity);
        Task DeleteAsync(int id);
    }
}
