using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;

        public string Email { get; set; } = default!;
        public string CommnentHeader { get; set; } = default!;
        public string CommentText { get; set; } = default!;
        public DateTime CommentTime { get; set; }
        public int PostId { get; set; }
        public virtual Post Post { get; set; } = default!;
    }
}
