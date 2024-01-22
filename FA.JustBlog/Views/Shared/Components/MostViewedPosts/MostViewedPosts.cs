using FA.JustBlog.Services.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Views.Shared.Components.MostViewedPosts
{
    public class MostViewedPosts : ViewComponent
    {
        private readonly IPostService _postService;
        public MostViewedPosts(IPostService postService)
        {
            _postService = postService;
        }
        public IViewComponentResult Invoke()
        {
            var mostViewedPosts = _postService.GetMostViewedPosts(3);
            return View(mostViewedPosts);
        }
    }
}
