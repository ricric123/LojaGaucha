namespace LojaGaucha.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClienteIDVendas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vendas", "ClienteID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vendas", "ClienteID");
        }
    }
}
