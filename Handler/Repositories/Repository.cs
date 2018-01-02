using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using PS2017ESOL.Services.DataContainerServices.Core.Repositories;

namespace PS2017ESOL.Services.DataContainerServices.Handler.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        DbContext _db;

        protected Repository(DbContext context)
        {
            _db = context;
        }

        #region Implementation of IDisposable

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Implementation of IRepository<T>

        public void Add(TEntity entity)
        {
            _db.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _db.Set<TEntity>().AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            _db.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _db.Set<TEntity>().RemoveRange(entities);
        }

        public TEntity Get(int id)
        {
            return _db.Set<TEntity>().Find(id);
        }

        public ICollection<TEntity> GetAll()
        {
            return _db.Set<TEntity>().ToList();
        }

        public ICollection<TEntity> Find(Func<TEntity, bool> predicate)
        {
            return _db.Set<TEntity>().Where(predicate).ToList();
        }

        public TEntity Find(params object[] id)
        {
            return _db.Set<TEntity>().Find(id);
        }

        public void Update(TEntity entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }

        #endregion
    }
}