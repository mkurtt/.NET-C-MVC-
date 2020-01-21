namespace Vektorel.EMarket.Datacore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Door = c.String(),
                        Building = c.String(),
                        Street = c.String(),
                        Avenue = c.String(),
                        County = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Country = c.String(),
                        CustomerKey = c.Guid(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Main.Customers", t => t.CustomerKey)
                .Index(t => t.CustomerKey);
            
            CreateTable(
                "Main.Customers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Surname = c.String(),
                        IdentityNumber = c.String(),
                        City = c.String(),
                        Country = c.String(),
                        BirthDate = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        UserId = c.Int(nullable: false),
                        Debit = c.Decimal(nullable: false, storeType: "money"),
                        Credit = c.Decimal(nullable: false, storeType: "money"),
                        Balance = c.Decimal(nullable: false, storeType: "money"),
                        CreatedAt = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        UpdatedAt = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Management.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId, unique: true);
            
            CreateTable(
                "Accounting.Invoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InvoiceNumber = c.Guid(nullable: false),
                        InvoiceDate = c.DateTime(nullable: false),
                        CustomerKey = c.Guid(nullable: false),
                        Debit = c.Decimal(nullable: false, storeType: "money"),
                        Credit = c.Decimal(nullable: false, storeType: "money"),
                        Balance = c.Decimal(nullable: false, storeType: "money"),
                        TaxAppliedBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedAt = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        UpdatedAt = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Main.Customers", t => t.CustomerKey, cascadeDelete: true)
                .Index(t => t.CustomerKey);
            
            CreateTable(
                "Accounting.InvoiceLines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductKey = c.Guid(nullable: false),
                        UnitType = c.String(),
                        UnitValue = c.Int(nullable: false),
                        Total = c.Decimal(nullable: false, storeType: "money"),
                        TotalWithTax = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InvoiceId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        UpdatedAt = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Product_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Accounting.Invoices", t => t.InvoiceId, cascadeDelete: true)
                .ForeignKey("Main.Products", t => t.Product_Id)
                .Index(t => t.InvoiceId)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "Main.Products",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 500),
                        Description = c.String(nullable: false, maxLength: 4000),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UserId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        UpdatedAt = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Management.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "Main.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderNumber = c.String(nullable: false, maxLength: 200),
                        OrderTotal = c.Decimal(nullable: false, storeType: "money"),
                        CustomerKey = c.Guid(nullable: false),
                        Status = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        UpdatedAt = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Main.Customers", t => t.CustomerKey)
                .Index(t => t.OrderNumber, unique: true)
                .Index(t => t.CustomerKey);
            
            CreateTable(
                "Management.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 200),
                        Password = c.String(nullable: false, maxLength: 64, fixedLength: true),
                        FullName = c.String(),
                        LastLogin = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        PicturePath = c.String(),
                        CreatedAt = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        UpdatedAt = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Email, unique: true);
            
            CreateTable(
                "Management.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        CreatedAt = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        UpdatedAt = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "Management.Modules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        RouteOrPath = c.String(),
                        CreatedAt = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        UpdatedAt = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "Intersections.OrderProducts",
                c => new
                    {
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderId, t.ProductId })
                .ForeignKey("Main.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("Main.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "Intersections.RoleModules",
                c => new
                    {
                        ModuleId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ModuleId, t.RoleId })
                .ForeignKey("Management.Modules", t => t.ModuleId, cascadeDelete: true)
                .ForeignKey("Management.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.ModuleId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "Intersections.UserRoles",
                c => new
                    {
                        RoleId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("Management.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("Management.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Main.Customers", "UserId", "Management.Users");
            DropForeignKey("Accounting.InvoiceLines", "Product_Id", "Main.Products");
            DropForeignKey("Main.Products", "UserId", "Management.Users");
            DropForeignKey("Intersections.UserRoles", "UserId", "Management.Users");
            DropForeignKey("Intersections.UserRoles", "RoleId", "Management.Roles");
            DropForeignKey("Intersections.RoleModules", "RoleId", "Management.Roles");
            DropForeignKey("Intersections.RoleModules", "ModuleId", "Management.Modules");
            DropForeignKey("Intersections.OrderProducts", "ProductId", "Main.Products");
            DropForeignKey("Intersections.OrderProducts", "OrderId", "Main.Orders");
            DropForeignKey("Main.Orders", "CustomerKey", "Main.Customers");
            DropForeignKey("Accounting.InvoiceLines", "InvoiceId", "Accounting.Invoices");
            DropForeignKey("Accounting.Invoices", "CustomerKey", "Main.Customers");
            DropForeignKey("dbo.Addresses", "CustomerKey", "Main.Customers");
            DropIndex("Intersections.UserRoles", new[] { "UserId" });
            DropIndex("Intersections.UserRoles", new[] { "RoleId" });
            DropIndex("Intersections.RoleModules", new[] { "RoleId" });
            DropIndex("Intersections.RoleModules", new[] { "ModuleId" });
            DropIndex("Intersections.OrderProducts", new[] { "ProductId" });
            DropIndex("Intersections.OrderProducts", new[] { "OrderId" });
            DropIndex("Management.Modules", new[] { "Name" });
            DropIndex("Management.Roles", new[] { "Name" });
            DropIndex("Management.Users", new[] { "Email" });
            DropIndex("Main.Orders", new[] { "CustomerKey" });
            DropIndex("Main.Orders", new[] { "OrderNumber" });
            DropIndex("Main.Products", new[] { "UserId" });
            DropIndex("Accounting.InvoiceLines", new[] { "Product_Id" });
            DropIndex("Accounting.InvoiceLines", new[] { "InvoiceId" });
            DropIndex("Accounting.Invoices", new[] { "CustomerKey" });
            DropIndex("Main.Customers", new[] { "UserId" });
            DropIndex("dbo.Addresses", new[] { "CustomerKey" });
            DropTable("Intersections.UserRoles");
            DropTable("Intersections.RoleModules");
            DropTable("Intersections.OrderProducts");
            DropTable("Management.Modules");
            DropTable("Management.Roles");
            DropTable("Management.Users");
            DropTable("Main.Orders");
            DropTable("Main.Products");
            DropTable("Accounting.InvoiceLines");
            DropTable("Accounting.Invoices");
            DropTable("Main.Customers");
            DropTable("dbo.Addresses");
        }
    }
}
