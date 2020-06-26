using System.Threading.Tasks;
using Domain.Model.Entities;
using Domain.Model.Exceptions;
using Domain.Model.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationMVC.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly IBlobService _blobService;

        public PostController(
            IPostService postService,
            IBlobService blobService)
        {
            _postService = postService;
            _blobService = blobService;
        }
        // GET: Post
        public async Task<IActionResult> Index()
        {
            var posts = await _postService.GetAllAsync();
            if (posts == null)
                return Redirect("/Identity/Account/Login");
            return View(posts);
        }

        // GET: Post/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _postService.GetByIdAsync(id.Value);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: Post/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Post/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PostEntity postEntity, IFormFile UrlPhoto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var uri = _blobService.StoragePost(UrlPhoto);
                    postEntity.UrlPhoto = uri.ToString();
                    await _postService.Send(postEntity);
                    return RedirectToAction(nameof(Index));
                }
                catch (EntityValidationException e)
                {
                    ModelState.AddModelError(e.PropertyName, e.Message);
                }
            }
            return View(postEntity);
        }

        // GET: Post/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _postService.GetByIdAsync(id.Value);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        // POST: Post/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, PostEntity postEntity)
        {
            if (id != postEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //var uri = _blobService.StoragePost(UrlPhoto);
                    //postEntity.UrlPhoto = uri.ToString();
                    await _postService.UpdateAsync(postEntity);
                }
                catch (EntityValidationException e)
                {
                    ModelState.AddModelError(e.PropertyName, e.Message);
                    return View(postEntity);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await _postService.GetByIdAsync(id) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(postEntity);
        }

        // GET: Post/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            var post = await _postService.GetByIdAsync(id.Value);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Post/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _postService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}