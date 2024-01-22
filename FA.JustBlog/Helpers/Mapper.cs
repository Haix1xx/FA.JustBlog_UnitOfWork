using FA.JustBlog.Areas.Admin.Models;
using FA.JustBlog.Core.Models;

namespace FA.JustBlog.Helpers
{
    public static class Mapper
    {
        public static Post PostDTOToPost(PostDTO createdPost)
        {
            return new Post
            {
                Id = createdPost.Id,
                Title = createdPost.Title,
                CategoryId = createdPost.CategoryId,
                ShortDescription = createdPost.ShortDescription,
                PostContent = createdPost.PostContent,
                UrlSlug = createdPost.UrlSlug,
                Published = createdPost.Published,
                PostedOn = createdPost.PostedOn
            };
        }

        public static PostDTO PostToPostDTO(Post post)
        {
            return new PostDTO
            {
                Id = post.Id,
                Title = post.Title,
                CategoryId = post.CategoryId,
                ShortDescription = post.ShortDescription,
                PostContent = post.PostContent,
                UrlSlug = post.UrlSlug,
                Published = post.Published,
                Modified = post.Modified,
                PostedOn = post.PostedOn,
                RateCount = post.RateCount,
                TotalRate = post.TotalRate,
                ViewCount = post.ViewCount,
            };
        }

        public static Category CategoryDTOToCategory(CategoryDTO categoryDTO)
        {
            return new Category
            {
                Id = categoryDTO.Id,
                Name = categoryDTO.Name,
                Description = categoryDTO.Description,
                UrlSlug = categoryDTO.UrlSlug
            };
        }

        public static CategoryDTO CategoryToCategoryDTO(Category category)
        {
            return new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                UrlSlug = category.UrlSlug,
            };
        }
    }
}