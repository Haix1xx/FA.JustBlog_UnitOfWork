using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Models.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Description).HasMaxLength(1024);
            builder.Property(x => x.UrlSlug).IsRequired().HasMaxLength(255);

            builder.HasData(
                new Category
                {
                    Id = 1,
                    Name = "News",
                    UrlSlug = "news",
                    Description = "latest news"
                },
                new Category
                {
                    Id = 2,
                    Name = "Sport",
                    UrlSlug = "sport",
                    Description = "latest news about sport"
                },
                new Category
                {
                    Id = 3,
                    Name = "Music",
                    UrlSlug = "music",
                    Description = "latest news about music"
                });
        }
    }
}
