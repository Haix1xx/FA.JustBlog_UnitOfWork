using FA.JustBlog.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FA.JustBlog.Areas.Admin.Pages.Role
{
    public class UserModel : PageModel
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserModel(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;

        }


        public class UserRole : AppUser
        {
            public string Roles { get; set; } = default!;
        }
        public IEnumerable<UserRole> Users { get; set; } = Enumerable.Empty<UserRole>();

        [TempData]
        public string StatusMessage { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync()
        {
            Users = _userManager.Users.Select(x => new UserRole { UserName = x.UserName, Id = x.Id }).ToList();

            foreach(var user in Users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                user.Roles = string.Join(",", roles.ToList());
            }

            return Page();
        }
    }
}
