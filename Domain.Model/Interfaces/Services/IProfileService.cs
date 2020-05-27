using System.Threading.Tasks;

namespace Domain.Model.Interfaces.Services
{
    public interface IProfileService
    {
        Task<ProfileEntity> GetByIdAsync(int id);
        Task InsertAsync(ProfileEntity insertedEntity);
        Task UpdateAsync(ProfileEntity updatedEntity);
    }
}
