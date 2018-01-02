using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PS2017ESOL.Services.DataContainerServices.Core.Factories;

namespace PS2017ESOL.Services.DataContainerServices.Handler.Factories
{
    public class DbContextObject<T> : IDbContextObject<T> where T : new()
    {
        public T GetInstance()
        {
            return new T();
        }
    }
}