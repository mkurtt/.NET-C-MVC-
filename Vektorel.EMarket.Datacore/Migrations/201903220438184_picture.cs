namespace Vektorel.EMarket.Datacore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class picture : DbMigration
    {
        public override void Up()
        {
            AddColumn("Main.Products", "MainPicturePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("Main.Products", "MainPicturePath");
        }
    }
}
