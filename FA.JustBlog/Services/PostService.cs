using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories.Repository.Abstractions;
using FA.JustBlog.Services.Services.Abstractions;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography.Xml;

namespace FA.JustBlog.Services
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PostService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<Post> GetAll()
        {
            return _unitOfWork.PostRepository.GetAll(includedProperties: "Category").ToList();
        }

        public Post? Find(int id) => _unitOfWork.PostRepository.Find(p => p.Id == id, "Category,PostTags.Tag", tracked: false);
        public void Delete(int id)
        {
            var post = Find(id);
            if (post != null)
            {
                _unitOfWork.PostRepository.Remove(post);
                _unitOfWork.Commit();
            }

        }
        public void Add(Post post)
        {
            post.PostedOn = post.Modified = DateTime.Now;

            _unitOfWork.PostRepository.Add(post);
            _unitOfWork.Commit();
        }
        public void Add(Post post, IEnumerable<int> tagIds)
        {
            post.PostTags = tagIds.Select(tag => new PostTag {  TagId =  tag }).ToList();
            Add(post);
        }
        public void Update(Post post)
        {
            post.Modified = DateTime.Now;
            _unitOfWork.PostRepository.Update(post);
            _unitOfWork.Commit();
            //_unitOfWork.UntrackEntity(post);
        }
        public void Update(Post post, IEnumerable<int> tagIds)
        {
            var existingPost = Find(post.Id);
            if (existingPost == null)
            {
                return;
            }
            var oldTags = existingPost.PostTags.Select(pt => pt.TagId);
            var addedTags = tagIds.Where(id => !oldTags.Contains(id));

            var removedPostTags = existingPost.PostTags.Where(pt => !tagIds.Contains(pt.TagId));

            _unitOfWork.PostTagRepository.RemoveRange(removedPostTags);
            _unitOfWork.Commit();
            post.PostTags = addedTags.Select(tag => new PostTag { TagId = tag }).ToList();
            Update(post);
        }
        public IEnumerable<Post> GetHighestPosts(int size)
        {
            return _unitOfWork.PostRepository.GetAll(includedProperties: "Category").OrderByDescending(p => p.Rate).Take(size).ToList();
        }

        public IEnumerable<Post> GetLatestPosts(int size)
        {
            return _unitOfWork.PostRepository.GetAll(includedProperties: "Category").OrderByDescending(p => p.PostedOn).Take(size).ToList();
        }

        public IEnumerable<Post> GetMostViewedPosts(int size)
        {
            return _unitOfWork.PostRepository.GetAll(includedProperties: "Category").OrderByDescending(p => p.ViewCount).Take(size).ToList();
        }

        public IEnumerable<Post> GetPostsByCategory(string category)
        {
            var existedCategory = _unitOfWork.CategoryRepository.Find(c => c.Name.ToLower().Equals(category.ToLower()), "Posts");
            if (existedCategory != null)
            {
                return existedCategory.Posts.ToList();
            }
            return Array.Empty<Post>();
        }

        public IEnumerable<Post> GetPostsByMonth(DateTime monthYear)
        {
            return _unitOfWork.PostRepository.GetAll(p => p.PostedOn.Month == monthYear.Month && p.PostedOn.Year == monthYear.Year).ToList();
        }

        public IEnumerable<Post> GetPostsByTag(string tag)
        {
            var existedTag = _unitOfWork.TagRepository.Find(t => t.Name.ToLower().Equals(tag.ToLower()), "PostTags.Post");
            if (existedTag != null)
            {
                return existedTag.PostTags.Select(pt => pt.Post);
            }
            return Array.Empty<Post>();
        }

        public IEnumerable<Post> GetPublishedPosts()
        {
            return _unitOfWork.PostRepository.GetAll(p => p.Published, "Category").ToList();
        }

        public IEnumerable<Post> GetUnpublishedPosts()
        {
            return _unitOfWork.PostRepository.GetAll(p => !p.Published, "Category").ToList();
        }

        public Post? Find(int year, int month, string? slug)
        {
            return _unitOfWork.PostRepository.Find(p => p.PostedOn.Year == year && p.PostedOn.Month == month && p.UrlSlug.Equals(slug), "Category,PostTags.Tag");
        }
    }
}
