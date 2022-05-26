using System.Collections;
using System.Linq.Expressions;

namespace WebTestApplication.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        //T is Category

        // Drzewo wyrażeń
        T GetFirstOrDefault(Expression<Func<T, bool>>filter, string? includeProperties = null);

        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null);

        void Add(T entity);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entity);


    }
}
