using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Views.Shared.Components.AboutCard
{
    public class AboutCard : ViewComponent
    {
        public AboutCard() { }
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
