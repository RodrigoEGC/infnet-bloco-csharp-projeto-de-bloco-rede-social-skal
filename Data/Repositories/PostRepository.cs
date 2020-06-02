using Domain.Model;
using Domain.Model.Entities;
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

        public async Task<IEnumerable<PostEntity>> GetAllAsync()
        {
            return await _userContext.Posts.ToListAsync();
        }

        public async Task Send (PostEntity postEntity)
        {
            _userContext.Add(postEntity);
            await _userContext.SaveChangesAsync();
        }
    }
}
