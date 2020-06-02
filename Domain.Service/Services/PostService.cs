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
        public async Task<IEnumerable<PostEntity>> GetAllAsync()
        {
            return await _postRepository.GetAllAsync();
        }

        public async Task Send(PostEntity postEntity)
        {
           await _postRepository.Send(postEntity);
        }
    }
}
