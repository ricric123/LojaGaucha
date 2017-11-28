namespace LojaGaucha.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProdutoQuantidadeTOINT : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Produtos", "ProdutoQuantidade", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Produtos", "ProdutoQuantidade", c => c.String());
        }
    }
}
