using System.ComponentModel.DataAnnotations;

namespace FA.JustBlog.Areas.Admin.Models
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = default!;
        [Required]
        [MaxLength(255)]
        [RegularExpression("^[^\\s\\,]+$")]
        public string UrlSlug { get; set; } = default!;
        public string? Description { get; set; }
    }
}
