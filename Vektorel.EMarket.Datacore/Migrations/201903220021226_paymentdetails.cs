namespace Vektorel.EMarket.Datacore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class paymentdetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("Main.Orders", "PaymentCode", c => c.String());
            AddColumn("Main.Orders", "PaymentType", c => c.Int(nullable: false));
            AddColumn("Main.Orders", "Agent", c => c.String());
            AddColumn("Main.Orders", "PaymentCurrency", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("Main.Orders", "PaymentCurrency");
            DropColumn("Main.Orders", "Agent");
            DropColumn("Main.Orders", "PaymentType");
            DropColumn("Main.Orders", "PaymentCode");
        }
    }
}
