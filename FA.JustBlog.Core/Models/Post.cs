using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Models
{
    public class Post
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Title { get; set; } = default!;
        [MaxLength(255)]
        public string? ShortDescription { get; set; }
        [Required]
        [MaxLength(10000)]
        public string PostContent { get; set; } = default!;
        [Required]
        [MaxLength(255)]
        public string UrlSlug { get; set; } = default!;
        public bool Published { get; set; }
        public DateTime PostedOn { get; set; }
        public DateTime Modified { get; set; } = default!;
        public int ViewCount { get; set; }
        public int RateCount { get; set; }
        public int TotalRate { get; set; }
        public decimal Rate
        {
            get
            {
                return RateCount > 0 ? (decimal)TotalRate / RateCount : 0;
            }
            set
            {
                if (RateCount > 0)
                    _ = TotalRate / RateCount;
            }
        }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; } = default!;
        public virtual ICollection<PostTag> PostTags { get; set; } = new List<PostTag>();
        public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
    }
}
