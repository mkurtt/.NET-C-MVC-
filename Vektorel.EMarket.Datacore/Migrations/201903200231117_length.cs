namespace Vektorel.EMarket.Datacore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class length : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Main.Customers", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("Main.Customers", "Surname", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("Main.Customers", "IdentityNumber", c => c.String(maxLength: 100));
            AlterColumn("Main.Customers", "City", c => c.String(maxLength: 100));
            AlterColumn("Main.Customers", "Country", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("Main.Customers", "Country", c => c.String());
            AlterColumn("Main.Customers", "City", c => c.String());
            AlterColumn("Main.Customers", "IdentityNumber", c => c.String());
            AlterColumn("Main.Customers", "Surname", c => c.String());
            AlterColumn("Main.Customers", "Name", c => c.String());
        }
    }
}
