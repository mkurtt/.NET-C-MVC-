using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vektorel.EMarket.Domain.Constants;
using Vektorel.EMarket.Domain.Model.EMarketDb;

namespace Vektorel.EMarket.Datacore.Context.Mapping
{
    public class CustomerMap : BaseEntityMap<Customer>
    {
        public CustomerMap()
        {

            ToTable(DbConstants.Customers.Name, DbConstants.Customers.Schema);

            HasKey(x => x.Id);


            Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            Property(x => x.Surname)
                .HasMaxLength(100)
                .IsRequired();

            Property(x => x.IdentityNumber)
               .HasMaxLength(100)
               .IsOptional();


            Property(x => x.BirthDate)
                .HasColumnType("datetime2");

            Property(x => x.City)
                .HasMaxLength(100)
                .IsOptional();

            Property(x => x.Country)
                .HasMaxLength(100)
                .IsOptional();

            Property(x => x.Balance)
               .HasColumnType("money")
               .IsRequired();

            Property(x => x.Debit)
               .HasColumnType("money")
               .IsRequired();

            Property(x => x.Credit)
               .HasColumnType("money")
               .IsRequired();

            HasMany(x => x.Addresses)
                .WithRequired(x => x.Customer)
                .HasForeignKey(x => x.CustomerKey)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.User)
               .WithMany()
               .HasForeignKey(x => x.UserId)
               .WillCascadeOnDelete(true);

            HasIndex(x => x.UserId)
                .IsUnique(true);



        }
    }
}
