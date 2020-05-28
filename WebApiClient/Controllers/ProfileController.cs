using Domain.Model;
using Domain.Model.Exceptions;
using Domain.Model.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }
        // GET: api/Profile
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProfileEntity>>> GetProfile()
        {
            var profiles = await _profileService.GetAllAsync();
            return profiles.ToList();
        }

        // GET: api/Profile/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProfileEntity>> GetProfile(int id)
        {
            if (id <= 0) 
            { 
                return NotFound(); 
            }
            var profile = await _profileService.GetByIdAsync(id); 
            if (profile == null) 
            { 
                return NotFound(); 
            }
            return profile;
        }

        // POST: api/Profile
        [HttpPost]
        public async Task<ActionResult<ProfileEntity>> PostProfile(ProfileEntity profileEntity)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                await _profileService.InsertAsync(profileEntity);
                return CreatedAtAction("GetLivroEntity", new { id = profileEntity.Id }, profileEntity);
            }
            catch (EntityValidationException e)
            {
                ModelState.AddModelError(e.PropertyName, e.Message); return BadRequest(ModelState);
            }
        }
        // PUT: api/Profile/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutProfile(int id, ProfileEntity profileEntity)
        {
            if (id != profileEntity.Id) 
            {
                return BadRequest(); 
            }
            try 
            { 
                await _profileService.UpdateAsync(profileEntity); 
            } 
            catch (EntityValidationException e) 
            { 
                ModelState.AddModelError(e.PropertyName, e.Message); 
                return BadRequest(ModelState); 
            }

            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
