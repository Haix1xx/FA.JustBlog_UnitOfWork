using FA.JustBlog.Models;
using FA.JustBlog.Services.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FA.JustBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITagService _tagService;
        public HomeController(ILogger<HomeController> logger, ITagService tagService)
        {
            _logger = logger;
            _tagService = tagService;
        }

        public IActionResult Index()
        {
            
            return RedirectToAction("Index", "Post");
        }

        public IActionResult Privacy()
        {
            var tags = _tagService.PopularTags(5);
            var a =  tags.FirstOrDefault()?.Name;
            Console.WriteLine(tags);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}