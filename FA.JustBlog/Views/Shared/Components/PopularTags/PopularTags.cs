using FA.JustBlog.Services.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Views.Shared.Components.PopularTags
{
    public class PopularTags : ViewComponent
    {
        private readonly ITagService _tagService;
        public PopularTags(ITagService tagService)
        {
            _tagService = tagService;
        }

        public IViewComponentResult Invoke()
        {
            var tags = _tagService.PopularTags(5);
            return View(tags);
        }
    }
}
