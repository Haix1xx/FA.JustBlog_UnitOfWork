using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Models.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(128);
            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasAnnotation("RegularExpression", @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$");

            builder.Property(c => c.CommnentHeader).IsRequired().HasMaxLength(128);
            builder.Property(c => c.CommentText).IsRequired().HasMaxLength(1024);
            builder.Property(c => c.CommentTime).IsRequired().HasDefaultValue(DateTime.Now);
            builder.HasOne(c => c.Post).WithMany(p => p.Comments).HasForeignKey(c => c.PostId);

            builder.HasData(
                new Comment
                {
                    Id = 1,
                    Name = "Jeans",
                    Email = "axxxxxxx2@gmail.com",
                    CommnentHeader = "Bad",
                    CommentText = "This is acctually good!",
                    PostId = 1
                },
                new Comment
                {
                    Id = 2,
                    Name = "John",
                    Email = "ahr2@gmail.com",
                    CommnentHeader = "Goods",
                    CommentText = "This is acctually good!",
                    PostId = 2
                },
                new Comment
                {
                    Id = 3,
                    Name = "Billie",
                    Email = "ahr224@gmail.com",
                    CommnentHeader = "Goods",
                    CommentText = "This is acctually good!xxx",
                    PostId = 2
                },
                new Comment
                {
                    Id = 4,
                    Name = "Ano",
                    Email = "ahro@gmail.com",
                    CommnentHeader = "Goods",
                    CommentText = "This is acctually good!",
                    PostId = 2
                },
                new Comment
                {
                    Id = 5,
                    Name = "Funny Guy",
                    Email = "funnyguy@gmail.com",
                    CommnentHeader = "Goods",
                    CommentText = "This is acctually good!",
                    PostId = 3
                }
                );
        }
    }
}
