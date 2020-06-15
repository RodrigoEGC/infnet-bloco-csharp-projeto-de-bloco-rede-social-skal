using System.Threading.Tasks;
using Domain.Model.Entities;
using Domain.Model.Exceptions;
using Domain.Model.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationMVC.Controllers
{
    [Authorize]
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
        public ActionResult Details(int id)
        {
            return View();
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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Post/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Post/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Post/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}