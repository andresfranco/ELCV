using System;
using System.Linq;
using System.Linq.Expressions;


namespace ELCV.Core.Interfaces
{
    public interface IAsyncRepository<T>
    {

        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
