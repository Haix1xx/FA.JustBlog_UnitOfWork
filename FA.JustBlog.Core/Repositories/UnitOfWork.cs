
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories.Repository.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly JustBlogContext _context;
        private ICategoryRepository _categoryRepository = default!;
        private IPostRepository _postRepository = default!;
        private ICommentRepository _commentRepository = default!;
        private ITagRepository _tagRepository = default!;
        private IPostTagRepository _postTagRepository = default!;
        public UnitOfWork(JustBlogContext context)
        {
            _context = context;
        }

        public ICategoryRepository CategoryRepository
        {
            get
            {
                _categoryRepository ??= new CategoryRepository(_context);
                return _categoryRepository;
            }
        }

        public IPostRepository PostRepository
        {
            get
            {
                _postRepository ??= new PostRepository(_context);
                return _postRepository;
            }
        }

        public ITagRepository TagRepository
        {
            get
            {
                _tagRepository ??= new TagRepository(_context);
                return _tagRepository;
            }
        }

        public ICommentRepository CommentRepository
        {
            get
            {
                _commentRepository ??= new CommentRepository(_context);
                return _commentRepository;
            }
        }

        public IPostTagRepository PostTagRepository
        {
            get
            {
                _postTagRepository ??= new PostTagRepository(_context);
                return _postTagRepository;
            }
        }
        public void Commit()
        {
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

        }

        public void RollBack()
        {
            _context.Dispose();
        }

        public void UntrackEntity<T>(T entity)
        {
            if (entity != null)
            {
                _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            }
        }
    }
}
