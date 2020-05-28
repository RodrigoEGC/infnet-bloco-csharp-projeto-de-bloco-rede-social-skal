using Domain.Model;
using Domain.Model.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Service
{
    public class ProfileService : IProfileService
    {
        public Task<IEnumerable<ProfileEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ProfileEntity> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task InsertAsync(ProfileEntity insertedEntity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ProfileEntity updatedEntity)
        {
            throw new NotImplementedException();
        }
    }
}
