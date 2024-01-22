using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Repositories.Repository.Abstractions
{
    public interface IUnitOfWork
    {
        ICategoryRepository CategoryRepository { get; }
        IPostRepository PostRepository { get; }
        ITagRepository TagRepository { get; }
        ICommentRepository CommentRepository { get; }
        IPostTagRepository PostTagRepository { get; }
        void Commit();
        void RollBack();
        void UntrackEntity<T>(T entity);
    }
}
