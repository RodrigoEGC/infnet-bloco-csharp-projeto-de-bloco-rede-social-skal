using Domain.Model;
using Domain.Model.Exceptions;
using Domain.Model.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly UserContext _userContext;
        public ProfileRepository(
            UserContext userContext)
        {
            _userContext = userContext;
        }
        public async Task<IEnumerable<ProfileEntity>> GetAllAsync()
        {
            return await _userContext.Users.ToListAsync();
        }

        public async Task<ProfileEntity> GetByIdAsync(int id)
        {
            return await _userContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task InsertAsync(ProfileEntity insertedEntity)
        {
            _userContext.Add(insertedEntity);
            await _userContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProfileEntity updatedEntity)
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
                    throw new RepositoryException("Perfil não encontrado!");
                }
                else
                {
                    throw;
                }
            }
        }
        public async Task DeleteAsync(int id)
        {
            var profileEntity = await _userContext.Users.FindAsync(id);
            _userContext.Users.Remove(profileEntity);
            await _userContext.SaveChangesAsync();
        }
    }
}
