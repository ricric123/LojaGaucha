namespace LojaGaucha.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPeso : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produtos", "Peso", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Produtos", "Peso");
        }
    }
}
