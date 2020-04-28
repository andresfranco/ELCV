using ELCV.Core.Common;
using ELCV.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ELCV.Infrastructure.Data
{
    public class EfAsyncRepository<T> : IAsyncRepository<T> where T : class
    {
        protected ELCVContext RepositoryContext;
        
        public EfAsyncRepository(ELCVContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
            
        }

        public IQueryable<T> FindAll()
        {
            return RepositoryContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return RepositoryContext.Set<T>()
                .Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            RepositoryContext.Set<T>().Add(entity);
           
        }

        public void Update(T entity)
        {
            RepositoryContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            RepositoryContext.Set<T>().Remove(entity);

        }
        public async Task<IEnumerable<T>> FindAllAsync()
        {
           return await FindAll().ToListAsync();
        }

        public async Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression)
        {   
            return await RepositoryContext.Set<T>().Where(expression).ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id) 
        {
            return await RepositoryContext.Set<T>().FindAsync(id);
        }

        public async Task CreateAsync(T entity)
        {
            RepositoryContext.Set<T>().Add(entity);
            await RepositoryContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(T entity)
        {
            RepositoryContext.Set<T>().Update(entity);
            await RepositoryContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(T entity)
        {   
            RepositoryContext.Set<T>().Remove(entity);
            await RepositoryContext.SaveChangesAsync();
        }

    }
}
