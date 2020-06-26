﻿using Domain.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Model.Interfaces.Repositories
{
    public interface IPostRepository
    {
        Task Send(PostEntity postEntity);

        Task<IEnumerable<PostEntity>> GetAllAsync();
        Task<PostEntity> GetByIdAsync(int id);
        Task UpdateAsync(PostEntity updatedEntity);
        Task DeleteAsync(int id);
    }
}
