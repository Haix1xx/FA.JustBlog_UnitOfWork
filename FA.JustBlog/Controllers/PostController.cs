using FA.JustBlog.Core.Models;
using FA.JustBlog.Services.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace FA.JustBlog.Controllers
{
    [Route("post")]
    public class PostController : Controller
    {
        private readonly ILogger<PostController> _logger;
        private readonly IPostService _postService;
        public PostController(IPostService postService, ILogger<PostController> logger)
        {
            _postService = postService;
            _logger = logger;
                   
        }

        [HttpGet("/")]
        
        public IActionResult Index()
        {
            
            var posts = _postService.GetLatestPosts(5);
            ViewData["Title"] = "Home";
            return View(posts);
        }
        [HttpGet("{id}")]
        public IActionResult Details([FromRoute]int id)
        {
            var post = _postService.Find(id);
            if (post == null)
            {
                return NotFound();
            }
            ViewData["Title"] = $"Post || {post.Title}";
            return View(post);
        }
        public IActionResult Tag([FromRoute]string tag)
        {
            var posts = _postService.GetPostsByTag(tag);
            return View("Index", posts);
        }

        [HttpGet("category/{category}")]
        public IActionResult PostsByCategory([FromRoute]string category)
        {
            
            if(string.IsNullOrEmpty(category))
            {
                BadRequest();
            }
            var posts = _postService.GetPostsByCategory(category);
            if (posts == null || posts?.Count() <= 0)
            {
                return NotFound();
            }

            ViewData["Title"] = $"Category || {category}";
            return View("Index", posts);
        }

        [HttpGet("{year}/{month}/{slug}")]
        public IActionResult Details(int year, int month, string? slug)
        {
            if (slug.IsNullOrEmpty())
            {
                return BadRequest();
            }

            var post = _postService.Find(year, month, slug);
            return View(post);
        }
    }
}
