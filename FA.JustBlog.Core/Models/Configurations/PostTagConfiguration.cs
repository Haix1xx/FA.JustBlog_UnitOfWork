using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Models.Configurations
{
    public class PostTagConfiguration : IEntityTypeConfiguration<PostTag>
    {
        public void Configure(EntityTypeBuilder<PostTag> builder)
        {
            builder.HasKey(pt => new { pt.PostId, pt.TagId });
            builder.HasOne(pt => pt.Post).WithMany(p => p.PostTags).HasForeignKey(p => p.PostId);
            builder.HasOne(pt => pt.Tag).WithMany(c => c.PostTags).HasForeignKey(c => c.TagId);

            builder.HasData(
                new PostTag
                {
                    PostId = 1,
                    TagId = 2,
                },
                new PostTag
                {
                    PostId = 1,
                    TagId = 3
                },
                new PostTag
                {
                    PostId = 2,
                    TagId = 3
                },
                new PostTag
                {
                    PostId = 3,
                    TagId = 2
                },
                new PostTag
                {
                    PostId = 4,
                    TagId = 3
                },
                new PostTag
                {
                    PostId = 5,
                    TagId = 3
                },
                new PostTag
                {
                    PostId = 5,
                    TagId = 1
                });
        }
    }
}
