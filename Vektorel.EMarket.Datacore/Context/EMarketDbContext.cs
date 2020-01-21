using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vektorel.EMarket.Datacore.Context.Mapping;
using Vektorel.EMarket.Domain.Model.EMarketDb;

namespace Vektorel.EMarket.Datacore.Context
{
    public class EMarketDbContext : DbContext
    {
        public EMarketDbContext() : base("name=EMarketDbCstr")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new ModuleMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new InvoiceMap());
            modelBuilder.Configurations.Add(new InvoiceLineMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new CatGroupMap());
            modelBuilder.Configurations.Add(new SaleMap());
            modelBuilder.Configurations.Add(new AddressMap());
            //base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<ApplicationUser> Users { get; set; }

        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<Module> Modules { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<Address> Addresses { get; set; }

        public virtual DbSet<Invoice> Invoices { get; set; }

        public virtual DbSet<InvoiceLine> InvoiceLines { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<CategoryGroup> CategoryGroups { get; set; }

        public virtual DbSet<Sale> Sales { get; set; }
    }
}
