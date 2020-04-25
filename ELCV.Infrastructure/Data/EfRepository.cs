using ELCV.Core.Common;
using ELCV.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ELCV.Infrastructure.Data
{
    public class EfRepository : IRepository
    {
        private readonly ELCVContext _dbContext;

        public EfRepository(ELCVContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T GetById<T>(int id) where T : Entity
        {
            return _dbContext.Set<T>().SingleOrDefault(e => e.Id == id);
        }

        public List<T> List<T>() where T : Entity
        {
            return _dbContext.Set<T>().ToList();
        }

        public T Add<T>(T entity) where T : Entity
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        public void Delete<T>(T entity) where T : Entity
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public void Update<T>(T entity) where T : Entity
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
