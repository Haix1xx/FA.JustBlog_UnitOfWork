using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Repositories.Repository.Abstractions
{
    public interface IBlogRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>>? expression = null, string? includedProperties = null);
        TEntity? Find(Expression<Func<TEntity, bool>>? expression = null, string? includedProperties = null, bool tracked = false);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
