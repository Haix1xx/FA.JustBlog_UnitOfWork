using FA.JustBlog.Services.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Views.Shared.Components.Categories
{
    public class Categories : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        public Categories(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _categoryService.GetAll();
            return View(categories);
        }
    }
}
