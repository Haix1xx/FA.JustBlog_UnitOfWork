using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories.Repository.Abstractions;
using FA.JustBlog.Services.Services.Abstractions;

namespace FA.JustBlog.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Category category)
        {
            _unitOfWork.CategoryRepository.Add(category);
            _unitOfWork.Commit();
        }

        public Category? Find(int id)
        {
            return _unitOfWork.CategoryRepository.Find(c => c.Id == id);
        }

        public IEnumerable<Category> GetAll()
        {
            return _unitOfWork.CategoryRepository.GetAll().ToList();
        }

        public void Remove(Category category)
        {
            _unitOfWork.CategoryRepository.Remove(category);
            _unitOfWork.Commit();
        }

        public void Update(Category category)
        {
            _unitOfWork.CategoryRepository.Update(category);
            _unitOfWork.Commit();
        }
    }
}
