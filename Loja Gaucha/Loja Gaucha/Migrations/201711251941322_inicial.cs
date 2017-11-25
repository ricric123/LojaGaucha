namespace Loja_Gaucha.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        CategoriaId = c.Int(nullable: false, identity: true),
                        CategoriaNome = c.String(),
                    })
                .PrimaryKey(t => t.CategoriaId);
            
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
                        Venda_VendaId = c.Int(),
                    })
                .PrimaryKey(t => t.ItemVendaId)
                .ForeignKey("dbo.Produtos", t => t.ProdutoId, cascadeDelete: true)
                .ForeignKey("dbo.Vendas", t => t.Venda_VendaId)
                .Index(t => t.ProdutoId)
                .Index(t => t.Venda_VendaId);
            
            CreateTable(
                "dbo.Produtos",
                c => new
                    {
                        ProdutoId = c.Int(nullable: false, identity: true),
                        ProdutoNome = c.String(nullable: false, maxLength: 100),
                        ProdutoDescricao = c.String(nullable: false, maxLength: 1000),
                        ProdutoPreco = c.Double(nullable: false),
                        ProdutoQuantidade = c.Int(nullable: false),
                        ProdutoImagem = c.String(),
                        CategoriaId = c.Int(nullable: false),
                        Peso = c.String(),
                    })
                .PrimaryKey(t => t.ProdutoId)
                .ForeignKey("dbo.Categorias", t => t.CategoriaId, cascadeDelete: true)
                .Index(t => t.CategoriaId);
            
            CreateTable(
                "dbo.Pessoas",
                c => new
                    {
                        PessoaId = c.Int(nullable: false, identity: true),
                        PessoaNome = c.String(nullable: false),
                        PessoaEmail = c.String(nullable: false),
                        ClienteSenha = c.String(nullable: false),
                        ClienteCPF = c.String(nullable: false),
                        ClienteTelefone = c.String(nullable: false),
                        PessoaNivel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PessoaId);
            
            CreateTable(
                "dbo.Vendas",
                c => new
                    {
                        VendaId = c.Int(nullable: false, identity: true),
                        ClienteID = c.Int(nullable: false),
                        CarrinhoId = c.String(),
                        Pessoa_PessoaId = c.Int(),
                    })
                .PrimaryKey(t => t.VendaId)
                .ForeignKey("dbo.Pessoas", t => t.Pessoa_PessoaId)
                .Index(t => t.Pessoa_PessoaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vendas", "Pessoa_PessoaId", "dbo.Pessoas");
            DropForeignKey("dbo.ItensVenda", "Venda_VendaId", "dbo.Vendas");
            DropForeignKey("dbo.ItensVenda", "ProdutoId", "dbo.Produtos");
            DropForeignKey("dbo.Produtos", "CategoriaId", "dbo.Categorias");
            DropIndex("dbo.Vendas", new[] { "Pessoa_PessoaId" });
            DropIndex("dbo.Produtos", new[] { "CategoriaId" });
            DropIndex("dbo.ItensVenda", new[] { "Venda_VendaId" });
            DropIndex("dbo.ItensVenda", new[] { "ProdutoId" });
            DropTable("dbo.Vendas");
            DropTable("dbo.Pessoas");
            DropTable("dbo.Produtos");
            DropTable("dbo.ItensVenda");
            DropTable("dbo.Categorias");
        }
    }
}
