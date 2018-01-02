using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS2017ESOL.Services.DataContainerServices.Core.Repositories.Abstract
{
    public interface IUnitOfWork<out T> : IDisposable where T : class // T is the repository class
    {
        T TargetModelObject { get; }
        int Complete();
    }
}