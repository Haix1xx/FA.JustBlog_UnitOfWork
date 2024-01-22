using FA.JustBlog.Core.Models;

namespace FA.JustBlog.Services.Services.Abstractions
{
    public interface ITagService
    {
        IEnumerable<Tag> PopularTags(int size);
        IEnumerable<Tag> GetAll();
        Tag? Find(int id);
        void Add(Tag tag);
        void Remove(Tag tag);
        void Update(Tag tag);
    }
}
