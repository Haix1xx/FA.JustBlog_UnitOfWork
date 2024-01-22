using FA.JustBlog.Core.Models;
using Microsoft.VisualBasic;

namespace FA.JustBlog.Services.Services.Abstractions
{
    public interface IPostService
    {
        IEnumerable<Post> GetAll();
        Post? Find(int id);
        Post? Find(int year, int month, string? slug);
        void Delete(int id);
        void Add(Post post);
        void Add(Post post, IEnumerable<int> tagIds);
        void Update(Post post);
        void Update(Post post, IEnumerable<int> tagTds);
        IEnumerable<Post> GetHighestPosts(int size);
        IEnumerable<Post> GetLatestPosts(int size);
        IEnumerable<Post> GetMostViewedPosts(int size);
        IEnumerable<Post> GetPostsByCategory(string category);
        IEnumerable<Post> GetPostsByMonth(DateTime monthYear);
        IEnumerable<Post> GetPostsByTag(string tag);
        IEnumerable<Post> GetPublishedPosts();
        IEnumerable<Post> GetUnpublishedPosts();
    }
}
