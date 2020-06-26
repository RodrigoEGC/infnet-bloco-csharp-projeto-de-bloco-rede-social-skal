using Domain.Model;
using Domain.Model.Entities;
using Domain.Model.Interfaces.Repositories;
using Domain.Model.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Service.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task DeleteAsync(int id)
        {
            await _postRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<PostEntity>> GetAllAsync()
        {
            return await _postRepository.GetAllAsync();
        }

        public async Task<PostEntity> GetByIdAsync(int id)
        {
            return await _postRepository.GetByIdAsync(id);
        }

        public async Task Send(PostEntity postEntity)
        {
           await _postRepository.Send(postEntity);
        }

        public async Task UpdateAsync(PostEntity updatedEntity)
        {
            await _postRepository.UpdateAsync(updatedEntity);
        }
    }
}
