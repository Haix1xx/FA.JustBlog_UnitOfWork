using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories.Repository.Abstractions;
using FA.JustBlog.Services.Services.Abstractions;

namespace FA.JustBlog.Services
{
    public class TagService : ITagService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TagService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Tag tag)
        {
            _unitOfWork.TagRepository.Add(tag);
            _unitOfWork.Commit();
        }

        public Tag? Find(int id)
        {
            return _unitOfWork.TagRepository.Find(t => t.Id == id);
        }

        public IEnumerable<Tag> GetAll()
        {
            return _unitOfWork.TagRepository.GetAll();
        }

        public IEnumerable<Tag> PopularTags(int size = 3)
        {
            var tags = _unitOfWork.PostTagRepository.GetAll().GroupBy(pt => pt.Tag).OrderByDescending(pt => pt.Count()).Select(p => p.Key).Take(size);

            return tags;
        }

        public void Remove(Tag tag)
        {
            _unitOfWork.TagRepository.Remove(tag);
            _unitOfWork.Commit();
        }

        public void Update(Tag tag)
        {
            _unitOfWork.TagRepository.Update(tag);
            _unitOfWork.Commit();
        }
    }
}
