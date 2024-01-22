using FA.JustBlog.Core.Models;

namespace FA.JustBlog.Services.Services.Abstractions
{
    public interface ICategoryService
    {
        public IEnumerable<Category> GetAll();
        public Category? Find(int id);
        public void Add(Category category);
        public void Update(Category category);
        public void Remove(Category category);
    }
}
