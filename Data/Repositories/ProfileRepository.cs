﻿using Domain.Model;
using Domain.Model.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        public Task<IEnumerable<ProfileEntity>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<ProfileEntity> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task InsertAsync(ProfileEntity insertedEntity)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(ProfileEntity updatedEntity)
        {
            throw new System.NotImplementedException();
        }
    }
}
