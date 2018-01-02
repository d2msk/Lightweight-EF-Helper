using System.Data.Entity;
using PS2017ESOL.Services.DataContainerServices.Core.Repositories.Abstract;

namespace PS2017ESOL.Services.DataContainerServices.Handler.Repositories
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class // T is the repository class
    {
        private readonly DbContext _context;
        private T t;
        private object s;

        /// <summary>
        /// Create UnitOfWork instance.
        /// </summary>
        /// <param name="context">Database context (entities) object.</param>
        /// <param name="targetModelObjectRepository">Such as PurchaseOrder repository object</param>
        public UnitOfWork(DbContext context, T targetModelObjectRepository)
        {
            _context = context;
            TargetModelObject = targetModelObjectRepository;
        }

        public UnitOfWork(T t, object s)
        {
            this.t = t;
            this.s = s;
        }

        /// <summary>
        /// Such as PurchaseOrder. 
        /// </summary>
        public T TargetModelObject { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}