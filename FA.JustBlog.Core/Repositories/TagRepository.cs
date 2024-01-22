using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories.Repository.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Repositories
{
    public class TagRepository : BlogRepository<Tag>, ITagRepository
    {
        public TagRepository(JustBlogContext context) : base(context) { }
    }
}
