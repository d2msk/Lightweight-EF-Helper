using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PS2017ESOL.Models.EF;
using PS2017ESOL.Services.DataContainerServices.Handler.Repositories;
using PS2017ESOL.Services.DataContainerServices.Handler.Repositories.Implementation;

namespace PS2017ESOL.Services.DataContainerServices.Handler.Factories
{
    public class DashboardFactory
    {
        public static UnitOfWork<DashboardRepository<DB_14098_ps14prodEntities>> ReadyUnitOfWorkInstance=>
            UnitOfWorkFactory<DB_14098_ps14prodEntities, DashboardRepository<DB_14098_ps14prodEntities>>.UnitOfWorkInstance();
    }
}