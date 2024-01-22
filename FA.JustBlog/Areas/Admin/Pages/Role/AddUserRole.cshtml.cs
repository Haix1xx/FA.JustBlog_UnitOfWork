using FA.JustBlog.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FA.JustBlog.Areas.Admin.Pages.Role
{
    public class AddUserRoleModel : PageModel
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AddUserRoleModel(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public class InputModel
        {
            [Required]
            public string Id { get; set; } = default!;
            public string? UserName { get; set; }
            public IEnumerable<string> Roles { get; set; } = new List<string>();
        }
        [BindProperty]
        public InputModel Input { set; get; } = new InputModel();
        [TempData]
        public string StatusMessage { get; set; } = default!;

        public IEnumerable<string> AllRoles { get; set; } = Enumerable.Empty<string>();
        public async Task<IActionResult> OnGetAsync([FromRoute] string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound("User Not Found");
            }
            AllRoles = await _roleManager.Roles.Select(x => x.Name ?? "").ToListAsync();
            Input.Id = user.Id;
            Input.UserName = user.UserName;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.FindByIdAsync(Input.Id);
            if (user == null)
            {
                return NotFound("User Not Found");
            }

            var roles = await _userManager.GetRolesAsync(user);
            var AllRoles = await _roleManager.Roles.Select(x => x.Name).ToListAsync();

            foreach(var role in Input.Roles)
            {
                if (roles.Contains(role)) continue;
                await _userManager.AddToRoleAsync(user, role);
            }
            foreach(var role in roles)
            {
                if (Input.Roles.Contains(role)) continue;
                await _userManager.RemoveFromRoleAsync(user, role);
            }

            Input.UserName = user.UserName;
            return RedirectToPage("User");
        }
    }
}
