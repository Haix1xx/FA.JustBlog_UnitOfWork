using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace FA.JustBlog.Areas.Admin.Pages.Role
{
    public class CreateModel : PageModel
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public CreateModel(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IEnumerable<IdentityRole> Roles { get; set; } = default!;
        [TempData]
        public string StatusMessage { get; set; } = default!;

        public class InputModel
        {
            [Display(Name = "Role Name")]
            [Required]
            [StringLength(256, MinimumLength = 2, ErrorMessage = "{0}'s length must be between {2} {1}")]
            public string Name { get; set; } = default!;
        }

        [BindProperty]
        public InputModel Input { get; set; } = default!;
        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var role = new IdentityRole(Input.Name);
            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                StatusMessage = "A role has been created successfully";
                return RedirectToPage("Index");
            }
            else
            {
                result.Errors.ToList().ForEach(error =>
                    ModelState.AddModelError(string.Empty, error.Description)
                );
            }

            return Page();
        }
    }
}
