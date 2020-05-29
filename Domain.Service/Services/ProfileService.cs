using Domain.Model;
using Domain.Model.Interfaces.Repositories;
using Domain.Model.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Service
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;

        public ProfileService(
            IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }
        public async Task<IEnumerable<ProfileEntity>> GetAllAsync()
        {
            return await _profileRepository.GetAllAsync();
        }

        public async Task<ProfileEntity> GetByIdAsync(int id)
        {
            return await _profileRepository.GetByIdAsync(id);
        }

        public async Task InsertAsync(ProfileEntity insertedEntity)
        {

           await _profileRepository.InsertAsync(insertedEntity);
        }

        public async Task UpdateAsync(ProfileEntity updatedEntity)
        {
            await _profileRepository.UpdateAsync(updatedEntity);
        }
    }
}
