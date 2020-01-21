using MAA.Basecore.Data.EntityFramework.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vektorel.EMarket.Datacore.Context;
using Vektorel.EMarket.Domain.Model.EMarketDb;

namespace Vektorel.EMarket.Datacore.Infrastructure
{
    public interface IOrderRepository : IRepository<Order>
    {

    }
    public class OrderRepository : Repository<EMarketDbContext, Order>, IOrderRepository
    {
        public OrderRepository(EMarketDbContext ctx) : base(ctx)
        {

        }
    }
}
