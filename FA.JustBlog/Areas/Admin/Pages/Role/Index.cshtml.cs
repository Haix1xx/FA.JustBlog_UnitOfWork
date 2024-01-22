using FA.JustBlog.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FA.JustBlog.Areas.Admin.Pages.Role
{
    public class IndexModel : PageModel
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public IndexModel(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IEnumerable<IdentityRole> Roles { get; set; } = default!;

        [TempData]
        public string StatusMessage { get; set; } = default!;
        public IActionResult OnGet()
        {
            Roles = _roleManager.Roles.ToList();
            ViewData["Title"] = "Role";
            return Page();
        }

        public IActionResult OnPost()
        {
            return RedirectToPage();
        }
    }
}
