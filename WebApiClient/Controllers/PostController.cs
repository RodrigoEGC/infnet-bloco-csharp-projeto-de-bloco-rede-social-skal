using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Model.Entities;
using Domain.Model.Exceptions;
using Domain.Model.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }
        // GET: api/Post
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostEntity>>> GetPostAll()
        {
            var posts = await _postService.GetAllAsync();
            return posts.ToList();
        }

        // GET: api/Post/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostEntity>> GetPost(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            var post = await _postService.GetByIdAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            return post;
        }

        // POST: api/Post
        [HttpPost]
        public async Task<ActionResult<PostEntity>> PostPostEntity(PostEntity postEntity)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                await _postService.Send(postEntity);
                return CreatedAtAction("GetPost", new { id = postEntity.Id }, postEntity);
            }
            catch (EntityValidationException e)
            {
                ModelState.AddModelError(e.PropertyName, e.Message); return BadRequest(ModelState);
            }
        }

        // PUT: api/Post/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, PostEntity postEntity)
        {
            if (id != postEntity.Id)
            {
                return BadRequest();
            }
            try
            {
                await _postService.UpdateAsync(postEntity);
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
        public async Task<ActionResult<PostEntity>> DeleteAsync(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var postEntity = await _postService.GetByIdAsync(id);
            if (postEntity == null)
            {
                return NotFound();
            }
            await _postService.DeleteAsync(id);

            return postEntity;
        }
    }
}
