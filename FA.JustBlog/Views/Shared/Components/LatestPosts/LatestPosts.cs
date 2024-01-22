using FA.JustBlog.Services.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Views.Shared.Components.LatestPosts
{
    public class LatestPosts : ViewComponent
    {
        private readonly IPostService _postService;
        public LatestPosts(IPostService postService)
        {
            _postService = postService;
        }
        public IViewComponentResult Invoke()
        {
            var posts = _postService.GetLatestPosts(5);
            return View(posts);
        }
    }
}
