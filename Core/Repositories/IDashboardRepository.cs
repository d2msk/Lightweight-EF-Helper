using PS2017ESOL.Models.EF;
using System;
using System.Collections.Generic;


namespace PS2017ESOL.Services.DataContainerServices.Core.Repositories
{
    public interface IDashboardRepository : IRepository<Models.EF.PurchaseOrder>
    {
        ICollection<Models.EF.PurchaseOrder> GetTopPurchaseOrders(short rowsCount);
        ICollection<dynamic> GetTopVendors(short rowsCount);
        ICollection<dynamic> GetTopDepartmentPerOrders(short rowsCount);
        ICollection<dynamic> GetTopDepartmentPerAmount(short rowsCount);
        ICollection<dynamic> GetTopGradesPerOrders(short rowsCount);
        ICollection<dynamic> GetTopGradesPerAmount(short rowsCount);
        ICollection<dynamic> GetTopRequestorsPerOrders(short rowsCount);
        ICollection<dynamic> GetTopRequestorsPerAmount(short rowsCount);
        UserProfile CurrentUserObject { get; }

        //IEnumerable<Models.EF.PurchaseOrder> GetUserPdRequests(int? teacherId, int? schoolId);
    }
}
