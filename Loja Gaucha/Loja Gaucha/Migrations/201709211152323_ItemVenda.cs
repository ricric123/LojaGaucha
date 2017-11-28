namespace LojaGaucha.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ItemVenda : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItensVenda",
                c => new
                    {
                        ItemVendaId = c.Int(nullable: false, identity: true),
                        ProdutoId = c.Int(nullable: false),
                        ItemVendaPreco = c.Double(nullable: false),
                        ItemVendaQuantidade = c.Int(nullable: false),
                        IdCarrinho = c.String(),
                        DataDaAdicao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ItemVendaId)
                .ForeignKey("dbo.Produtos", t => t.ProdutoId, cascadeDelete: true)
                .Index(t => t.ProdutoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItensVenda", "ProdutoId", "dbo.Produtos");
            DropIndex("dbo.ItensVenda", new[] { "ProdutoId" });
            DropTable("dbo.ItensVenda");
        }
    }
}
