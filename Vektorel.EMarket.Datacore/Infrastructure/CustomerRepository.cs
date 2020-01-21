using MAA.Basecore.Data.EntityFramework.Persistence;
using MAA.Basecore.Model.ResultTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vektorel.EMarket.Datacore.Context;
using Vektorel.EMarket.Domain.Model.EMarketDb;

namespace Vektorel.EMarket.Datacore.Infrastructure
{

    public interface ICustomerRepository : IRepository<Customer>
    {
        
    }
    public class CustomerRepository : Repository<EMarketDbContext, Customer>, ICustomerRepository
    {
        public CustomerRepository(EMarketDbContext ctx) : base(ctx)
        {

        }
    }
}
