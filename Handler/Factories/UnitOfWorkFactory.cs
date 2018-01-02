using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using PS2017ESOL.Services.DataContainerServices.Handler.Repositories;

namespace PS2017ESOL.Services.DataContainerServices.Handler.Factories
{
    /// <summary>
    /// Create UnitOfWork Instance.
    /// </summary>
    /// <typeparam name="T">DbContext object.</typeparam>
    /// <typeparam name="TT">Targeted database entity object repository class.</typeparam>
    public static class UnitOfWorkFactory<T, TT> where T : DbContext, new() where TT : class, new()
    {
        public static UnitOfWork<TT> UnitOfWorkInstance()
        {
            return new UnitOfWork<TT>(new T(), new TT());
        } 
    }
}