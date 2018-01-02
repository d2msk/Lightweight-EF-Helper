using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS2017ESOL.Services.DataContainerServices.Core.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entities);

        TEntity Get(int id);

        ICollection<TEntity> GetAll();

        ICollection<TEntity> Find(Func<TEntity, bool> predicate);

        TEntity Find(params object[] id);

        void Update(TEntity entity);
    }
}
