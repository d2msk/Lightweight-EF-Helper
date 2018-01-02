using System;
using System.Collections.Generic;
using System.Data.Entity;
using PS2017ESOL.Models.EF;
using PS2017ESOL.Services.DataContainerServices.Core.Repositories;
using PS2017ESOL.Services.DataContainerServices.Handler.Factories;
using System.Linq;

namespace PS2017ESOL.Services.DataContainerServices.Handler.Repositories.Implementation
{
    public class DashboardRepository<TContext> : Repository<PurchaseOrder>, IDashboardRepository 
        where TContext : DbContext, new()
    {
        private static DbContext _db;
        readonly ICollection<PurchaseOrder> _purchasrOrders;

        #region Implementation of IDashboardRepository

        public ICollection<PurchaseOrder> GetTopPurchaseOrders(short rowsCount)
        {
            if (_purchasrOrders.Count == 0) return default(ICollection<PurchaseOrder>);

            var qq = _purchasrOrders.GroupBy(x => x.POMainNumber).Select(po => new PurchaseOrder
                {
                    POMainNumber = po.First().POMainNumber,
                    TotalPrice = po.Sum(p => p.TotalPrice)
                }).OrderByDescending(a => a.TotalPrice)
                .Take(rowsCount)
                .ToList();
            return qq;
        }

        public ICollection<dynamic> GetTopVendors(short rowsCount)
        {
            var qq = _purchasrOrders.GroupBy(x => x.VendorId).Select(po => new 
                {
                    VendorFirstName = po.First().Vendor.FirstName,
                    TotalPrice = po.Sum(p => p.TotalPrice)
                }).OrderByDescending(a => a.TotalPrice)
                .Take(rowsCount)
                .ToList<dynamic>();
            return qq;
        }

        public ICollection<dynamic> GetTopDepartmentPerOrders(short rowsCount)
        {
            var qq = (from p in _purchasrOrders
                     group p by p.SchoolDeptId into g
                     join d in _db.Set<SchoolDepartment>() on g.Key equals d.Id
                     select new
                     {
                         DeptName = d.Dept,
                         POCount = g.Distinct().Count()
                     }).OrderByDescending(x=>x.POCount).Take(rowsCount).ToList<dynamic>();
            return qq;
        }

        public ICollection<dynamic> GetTopDepartmentPerAmount(short rowsCount)
        {
            var qq = (from p in _purchasrOrders
                     group p by p.SchoolDeptId into g
                     join d in _db.Set<SchoolDepartment>() on g.Key equals d.Id
                     select new
                     {
                         DeptName = d.Dept,
                         TotalPrice = g.Distinct().Sum(z=>z.TotalPrice)
                     }).OrderByDescending(x => x.TotalPrice).Take(rowsCount).ToList<dynamic>();

            return qq;
        }

        public ICollection<dynamic> GetTopGradesPerOrders(short rowsCount)
        {
            throw new NotImplementedException();
        }

        public ICollection<dynamic> GetTopGradesPerAmount(short rowsCount)
        {
            throw new NotImplementedException();
        }

        public ICollection<dynamic> GetTopRequestorsPerOrders(short rowsCount)
        {
            throw new NotImplementedException();
        }

        public ICollection<dynamic> GetTopRequestorsPerAmount(short rowsCount)
        {
            throw new NotImplementedException();
        }

        public UserProfile CurrentUserObject { get; }

        #endregion

        private DashboardRepository(DbContext context) : base(context)
        {
            _db = context;
            _purchasrOrders = this.Find(q => q.SchoolId == 1 && q.FileYear == 2018);
        }

        public DashboardRepository() : this(new TContext())
        {
            
        }
    }
}