using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract.Repository
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        T Get(int id);
        List<T>GetAll();
        IQueryable<T> GetEx(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
