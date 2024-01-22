using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Repositories
{
    public class BlogRepository<TEntity> : IBlogRepository<TEntity> where TEntity : class
    {
        protected readonly JustBlogContext _context;
        private readonly DbSet<TEntity> _entitySet;
        public BlogRepository(JustBlogContext context)
        {
            _context = context;
            _entitySet = context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _entitySet.Add(entity);
        }

        public void Remove(TEntity entity)
        {
            _entitySet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _entitySet.RemoveRange(entities);
        }
        public TEntity? Find(Expression<Func<TEntity, bool>>? expression = null, string? includedProperties = null, bool tracked = false)
        {
            IQueryable<TEntity> query;
            if (tracked)
            {
                query = _entitySet;
            }
            else
            {
                query = _entitySet.AsNoTracking();
            }

            if (expression != null)
            {
                query = query.Where(expression);
            }
            if (!includedProperties.IsNullOrEmpty())
            {
                foreach (var prop in includedProperties?.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries) ?? Array.Empty<string>())
                {
                    query = query.Include(prop);
                }
            }
            return query.FirstOrDefault();
        }


        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>>? expression = null, string? includedProperties = null)
        {
            IQueryable<TEntity> query = _entitySet.AsNoTracking();
            if (expression != null)
            {
                query = query.Where(expression);
            }
            if (!includedProperties.IsNullOrEmpty())
            {
                foreach (var prop in includedProperties?.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries) ?? Array.Empty<string>())
                {
                    query = query.Include(prop);
                }
            }
            return query;
        }

        public void Update(TEntity entity)
        {
            _entitySet.Update(entity);
        }
    }
}
