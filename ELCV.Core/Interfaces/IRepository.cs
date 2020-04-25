using ELCV.Core.Common;
using System.Collections.Generic;

namespace ELCV.Core.Interfaces
{
    public interface IRepository
    {
        T GetById<T>(int id) where T : Entity;
        List<T> List<T>() where T : Entity;
        T Add<T>(T entity) where T : Entity;
        void Update<T>(T entity) where T : Entity;
        void Delete<T>(T entity) where T : Entity;
    }
}