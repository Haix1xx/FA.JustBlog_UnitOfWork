using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Models
{
    public class AppUser : IdentityUser
    {
        public int Age { get; set; }
        [MaxLength(1024)]
        public string? About { get; set; } = default!;
    }
}
