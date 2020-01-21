namespace Vektorel.EMarket.Datacore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class category : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Main.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        GroupId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Main.CategoryGroups", t => t.GroupId)
                .Index(t => t.GroupId);
            
            CreateTable(
                "Main.CategoryGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Description = c.String(),
                        CreatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("Main.Products", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("Main.Products", "CategoryId");
            AddForeignKey("Main.Products", "CategoryId", "Main.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("Main.Products", "CategoryId", "Main.Categories");
            DropForeignKey("Main.Categories", "GroupId", "Main.CategoryGroups");
            DropIndex("Main.Categories", new[] { "GroupId" });
            DropIndex("Main.Products", new[] { "CategoryId" });
            DropColumn("Main.Products", "CategoryId");
            DropTable("Main.CategoryGroups");
            DropTable("Main.Categories");
        }
    }
}
