using Domain.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Model.Interfaces.Repositories
{
    public interface IPostRepository
    {
        Task Send(PostEntity postEntity);

        Task<IEnumerable<PostEntity>> GetAllAsync();
    }
}
