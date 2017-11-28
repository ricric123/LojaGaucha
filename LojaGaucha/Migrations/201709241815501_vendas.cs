namespace LojaGaucha.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vendas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vendas",
                c => new
                    {
                        VendaId = c.Int(nullable: false, identity: true),
                        CarrinhoId = c.String(),
                        Pessoa_PessoaId = c.Int(),
                    })
                .PrimaryKey(t => t.VendaId)
                .ForeignKey("dbo.Pessoas", t => t.Pessoa_PessoaId)
                .Index(t => t.Pessoa_PessoaId);
            
            AddColumn("dbo.ItensVenda", "Venda_VendaId", c => c.Int());
            CreateIndex("dbo.ItensVenda", "Venda_VendaId");
            AddForeignKey("dbo.ItensVenda", "Venda_VendaId", "dbo.Vendas", "VendaId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vendas", "Pessoa_PessoaId", "dbo.Pessoas");
            DropForeignKey("dbo.ItensVenda", "Venda_VendaId", "dbo.Vendas");
            DropIndex("dbo.Vendas", new[] { "Pessoa_PessoaId" });
            DropIndex("dbo.ItensVenda", new[] { "Venda_VendaId" });
            DropColumn("dbo.ItensVenda", "Venda_VendaId");
            DropTable("dbo.Vendas");
        }
    }
}
