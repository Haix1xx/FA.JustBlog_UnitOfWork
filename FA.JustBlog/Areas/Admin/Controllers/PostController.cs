using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FA.JustBlog.Core;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Services.Services.Abstractions;
using FA.JustBlog.Services;
using FA.JustBlog.Areas.Admin.Models;
using FA.JustBlog.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace FA.JustBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/post")]
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;
        private readonly ITagService _tagService;
        private readonly ILogger<PostController> _logger;
        public PostController(IPostService postService, ICategoryService categoryService, ITagService tagService, ILogger<PostController> logger)
        {
            _postService = postService;
            _categoryService = categoryService;
            _tagService = tagService;
            _logger = logger;
        }

        // GET: Admin/Post
        [Authorize(Roles = "Contributor,Blog Owner,User")]
        [HttpGet("")]
        public IActionResult Index()
        {
            var posts = _postService.GetAll();
            ViewData["Title"] = "All Posts";
            ViewData["TableName"] = "All Posts";
            return View(posts);
        }

        [Authorize(Roles = "Contributor,Blog Owner,User")]
        [HttpGet("most-viewed-posts")]
        public IActionResult MostViewedPosts()
        {
            var posts = _postService.GetMostViewedPosts(20);
            ViewData["Title"] = "Most Viewed Posts";
            return View("Index", posts);
        }

        [Authorize(Roles = "Contributor,Blog Owner,User")]
        [HttpGet("latest-posts")]
        public IActionResult LatestPosts()
        {
            var posts = _postService.GetLatestPosts(20);
            ViewData["Title"] = "Latest Posts";
            return View("Index", posts);
        }

        [Authorize(Roles = "Blog Owner")]
        [HttpGet("published-posts")]
        public IActionResult PublishedPosts()
        {
            var posts = _postService.GetPublishedPosts();
            ViewData["Title"] = "Published Posts";
            return View("Index", posts);
        }

        [Authorize(Roles = "Blog Owner")]
        [HttpGet("unpublished-posts")]
        public IActionResult UnpublishedPosts()
        {
            var posts = _postService.GetUnpublishedPosts();
            ViewData["Title"] = "Unpublished Posts";
            return View("Index", posts);
        }

        // GET: Admin/Post/Details/5
        [Authorize(Roles = "Contributor,Blog Owner,User")]
        [HttpGet("{id?}")]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var post = _postService.Find(id.Value);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: Admin/Post/Create
        [Authorize(Roles = "Contributor,Blog Owner")]
        [HttpGet("create")]
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_categoryService.GetAll(), "Id", "Name");
            ViewBag.TagId = new SelectList(_tagService.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Admin/Post/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Contributor,Blog Owner")]
        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Title,ShortDescription,PostContent,UrlSlug,Published,CategoryId,TagIds")] PostDTO post)
        {
            if (ModelState.IsValid)
            {
                _postService.Add(Mapper.PostDTOToPost(post), post.TagIds);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_categoryService.GetAll(), "Id", "Name", post.CategoryId);
            return View(post);
        }

        // GET: Admin/Post/Edit/5
        [Authorize(Roles = "Contributor,Blog Owner")]
        [HttpGet("edit/{id?}")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = _postService.Find(id.Value);
            if (post == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_categoryService.GetAll(), "Id", "Name", post.CategoryId);
            ViewData["TagId"] = new SelectList(_tagService.GetAll(), "Id", "Name");
            var postDTO = Mapper.PostToPostDTO(post);
            postDTO.TagIds = post.PostTags.Select(pt => pt.TagId).ToList();
            return View(postDTO);
        }

        // POST: Admin/Post/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Contributor,Blog Owner")]
        [HttpPost("edit/{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Title,ShortDescription,PostContent,UrlSlug,Published,PostedOn,Modified,ViewCount,RateCount,TotalRate,CategoryId,TagIds")] PostDTO post)
        {
            if (id != post.Id)
            {
                return NotFound();
            }
            _logger.LogError(ModelValidateMessage.GenerateMessages(ModelState));
            if (ModelState.IsValid)
            {
                try
                {
                    _postService.Update(Mapper.PostDTOToPost(post), post.TagIds);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.Id))
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
            ViewData["CategoryId"] = new SelectList(_categoryService.GetAll(), "Id", "Name", post.CategoryId);
            return View(post);
        }

        // GET: Admin/Post/Delete/5
        [Authorize(Roles = "Blog Owner")]
        [HttpGet("delete/{id?}")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = _postService.Find(id.Value);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Admin/Post/Delete/5
        [Authorize(Roles = "Blog Owner")]
        [HttpPost("delete/{id}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            //if (_context.Posts == null)
            //{
            //    return Problem("Entity set 'JustBlogContext.Posts'  is null.");
            //}
            var post = _postService.Find(id);
            if (post != null)
            {
                _postService.Delete(id);
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(int id)
        {
          return _postService.Find(id) != null;
        }
    }
}
