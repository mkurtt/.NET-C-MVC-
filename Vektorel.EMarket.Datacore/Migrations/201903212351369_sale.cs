namespace Vektorel.EMarket.Datacore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sale : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("Accounting.Invoices", "CustomerKey", "Main.Customers");
            DropIndex("Accounting.Invoices", new[] { "CustomerKey" });
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        SaleKey = c.Guid(nullable: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Main.Orders", t => t.OrderId)
                .Index(t => t.OrderId, unique: true);
            
            AddColumn("Accounting.Invoices", "SaleKey", c => c.Guid(nullable: false));
            AddColumn("Main.Products", "DiscountRate", c => c.Int(nullable: false));
            DropColumn("Accounting.Invoices", "CustomerKey");
        }
        
        public override void Down()
        {
            AddColumn("Accounting.Invoices", "CustomerKey", c => c.Guid(nullable: false));
            DropForeignKey("dbo.Sales", "OrderId", "Main.Orders");
            DropIndex("dbo.Sales", new[] { "OrderId" });
            DropColumn("Main.Products", "DiscountRate");
            DropColumn("Accounting.Invoices", "SaleKey");
            DropTable("dbo.Sales");
            CreateIndex("Accounting.Invoices", "CustomerKey");
            AddForeignKey("Accounting.Invoices", "CustomerKey", "Main.Customers", "Id", cascadeDelete: true);
        }
    }
}
