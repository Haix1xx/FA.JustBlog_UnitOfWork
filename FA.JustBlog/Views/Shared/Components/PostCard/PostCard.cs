using FA.JustBlog.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Views.Shared.Components.PostCard
{
    public class PostCard : ViewComponent
    {
        public IViewComponentResult Invoke(Post post)
        {
            return View(post);
        }
    }
}
