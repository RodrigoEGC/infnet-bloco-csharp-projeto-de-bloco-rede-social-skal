using Domain.Model;
using Domain.Model.Entities;
using Domain.Model.Exceptions;
using Domain.Model.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly UserContext _userContext;
        public PostRepository(UserContext userContext)
        {
            _userContext = userContext;
        }

        public async Task DeleteAsync(int id)
        {
            var postEntity = await _userContext.Posts.FindAsync(id);
            _userContext.Posts.Remove(postEntity);
            await _userContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<PostEntity>> GetAllAsync()
        {
            return await _userContext.Posts.ToListAsync();
        }

        public async Task<PostEntity> GetByIdAsync(int id)
        {
            return await _userContext.Posts.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Send (PostEntity postEntity)
        {
            _userContext.Add(postEntity);
            await _userContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(PostEntity updatedEntity)
        {
            try
            {
                _userContext.Update(updatedEntity);
                await _userContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await GetByIdAsync(updatedEntity.Id) == null)
                {
                    throw new RepositoryException("Post não encontrado!");
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
