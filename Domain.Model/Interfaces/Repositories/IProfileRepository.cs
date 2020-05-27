using System.Threading.Tasks;

namespace Domain.Model.Interfaces.Repositories
{
    public interface IProfileRepository
    {
        Task<ProfileEntity> GetByIdAsync(int id); 
        Task InsertAsync(ProfileEntity insertedEntity); 
        Task UpdateAsync(ProfileEntity updatedEntity);
    }
}
