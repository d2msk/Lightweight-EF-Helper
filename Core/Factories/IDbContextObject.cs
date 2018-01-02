using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS2017ESOL.Services.DataContainerServices.Core.Factories
{
    public interface IDbContextObject<T> where T : new()
    {
        T GetInstance();
    }
}
