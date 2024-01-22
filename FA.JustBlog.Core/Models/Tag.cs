using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string UrlSlug { get; set; } = default!;
        public string? Description { get; set; }
        public int Count { get; set; }
        public virtual ICollection<PostTag> PostTags { get; set; } = new HashSet<PostTag>();
    }
}
