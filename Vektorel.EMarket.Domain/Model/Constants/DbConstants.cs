using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vektorel.EMarket.Domain.Constants
{
    public static class DbConstants
    {

        public static readonly TableNameSchema ApplicationUsers = new TableNameSchema("Users", Management);

        public static readonly TableNameSchema Roles = new TableNameSchema("Roles", Management);

        public static readonly TableNameSchema Modules = new TableNameSchema("Modules", Management);

        public static readonly TableNameSchema UserRoles = new TableNameSchema("UserRoles", Intersections);

        public static readonly TableNameSchema RoleModules = new TableNameSchema("RoleModules", Intersections);

        public static readonly TableNameSchema Products = new TableNameSchema("Products", Main);

        public static readonly TableNameSchema Customers = new TableNameSchema("Customers", Main);

        public static readonly TableNameSchema Invoices = new TableNameSchema("Invoices", Accounting);

        public static readonly TableNameSchema InvoiceLines = new TableNameSchema("InvoiceLines", Accounting);

        public static readonly TableNameSchema Tickets = new TableNameSchema("Tickets", Main);

        public static readonly TableNameSchema TicketResponses = new TableNameSchema("TicketResponses", Main);

        public static readonly TableNameSchema Orders = new TableNameSchema("Orders", Main);

        public static readonly TableNameSchema OrderProducts = new TableNameSchema("OrderProducts", Intersections);

        public static readonly TableNameSchema Categories = new TableNameSchema("Categories", Main);

        public static readonly TableNameSchema CategoryGroups = new TableNameSchema("CategoryGroups", Main);

        public static readonly TableNameSchema Sales = new TableNameSchema("Sales", Main);

        public static readonly TableNameSchema Addresses = new TableNameSchema("Addresses", Main);




        //Schemas
        private const string Intersections = "Intersections";
        private const string Management = "Management";
        private const string Main = "Main";
        private const string Accounting = "Accounting";
    }

    public class TableNameSchema
    {
        public TableNameSchema(string name,string schema)
        {
            Name = name;
            Schema = schema;

            SchemaWithName = schema + "." + name;
        }

        public string Name { get; set; }

        public string Schema { get; set; }

        public string SchemaWithName { get; set; }
    }

}
