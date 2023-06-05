using Core.Entities;
using DataAccess.Abstract.Repository;
using DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Repository
{
    public class BaseRepository<TEntity> : IRepository<TEntity>
        where TEntity:class , IEntity, new()
    {
        private readonly EfNorthwindContext dbContext;

        public BaseRepository(EfNorthwindContext _dbcontext)
        {
            dbContext = _dbcontext;
        }

        public void Add(TEntity entity)
        {
            dbContext.Set<TEntity>().Add(entity);
            dbContext.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            dbContext.Set<TEntity>().Remove(entity);
            dbContext.SaveChanges();
        }

        public TEntity Get(int id)
        {
            return dbContext.Set<TEntity>().Find(id);
        }

        public List<TEntity> GetAll()
        {
            return dbContext.Set<TEntity>().ToList();
        }

        public IQueryable<TEntity> GetEx(Expression<Func<TEntity, bool>> filter)
        {
            return dbContext.Set<TEntity>().Where(filter).AsNoTracking();
        }

        public void Update(TEntity entity)
        {
            dbContext.Set<TEntity>().Update(entity);
            dbContext.SaveChanges();
        }
    }
}
