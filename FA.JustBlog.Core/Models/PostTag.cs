using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Models
{
    public class PostTag
    {
        public int PostId { get; set; }
        public int TagId { get; set; }
        public virtual Post Post { get; set; } = default!;
        public virtual Tag Tag { get; set; } = default!;
    }
}
