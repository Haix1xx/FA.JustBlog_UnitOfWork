using System.ComponentModel.DataAnnotations;

namespace FA.JustBlog.Areas.Admin.Models
{
    public class PostDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        
        public string Title { get; set; } = default!;
        [Required]
        [MaxLength(255)]
        public string? ShortDescription { get; set; }
        [Required]
        [MaxLength(10000)]
        public string PostContent { get; set; } = default!;
        [Required]
        [MaxLength(255)]
        [RegularExpression("^[^\\s\\,]+$")]
        public string UrlSlug { get; set; } = default!;
        public bool Published { get; set; }
        public int CategoryId { get; set; }
        public DateTime PostedOn { get; set; } = default!;
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

        public IEnumerable<int> TagIds { get; set; } = new List<int>();
    }
}
