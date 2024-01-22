using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core
{
    public class JustBlogContextFactory : IDesignTimeDbContextFactory<JustBlogContext>
    {
        public JustBlogContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<JustBlogContext>();
            options.UseSqlServer("Server=NGOCHAI\\SQLEXPRESS;Database=JustBlogContext;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=True;TrustServerCertificate=True; ");
            return new JustBlogContext(options.Options);
        }
    }
}
