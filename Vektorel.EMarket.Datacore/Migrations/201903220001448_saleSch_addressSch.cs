namespace Vektorel.EMarket.Datacore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class saleSch_addressSch : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "dbo.Addresses", newSchema: "Main");
            MoveTable(name: "dbo.Sales", newSchema: "Main");
            AlterColumn("Main.Addresses", "CreatedAt", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("Main.Addresses", "UpdatedAt", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("Main.Addresses", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("Main.Addresses", "CreatedAt", c => c.DateTime(nullable: false));
            MoveTable(name: "Main.Sales", newSchema: "dbo");
            MoveTable(name: "Main.Addresses", newSchema: "dbo");
        }
    }
}
