using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Models.Configurations
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.UrlSlug).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Description).HasMaxLength(1024);
            builder.HasIndex(x => x.UrlSlug);

            builder.HasData(
                new Tag
                {
                    Id = 1,
                    Name = "latest",
                    Description = "Description",
                    UrlSlug = "latest",
                    Count = 0
                },
                new Tag
                {
                    Id = 2,
                    Name = "hotest",
                    Description = "Description",
                    UrlSlug = "hotest",
                    Count = 0
                },
                new Tag
                {
                    Id = 3,
                    Name = "funny",
                    Description = "Description",
                    UrlSlug = "funny",
                    Count = 0
                });
        }
    }
}
