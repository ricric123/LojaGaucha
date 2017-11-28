namespace LojaGaucha.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BancoVersao1 : DbMigration
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
                "dbo.Produtos",
                c => new
                    {
                        ProdutoId = c.Int(nullable: false, identity: true),
                        ProdutoNome = c.String(nullable: false, maxLength: 100),
                        ProdutoDescricao = c.String(nullable: false, maxLength: 1000),
                        ProdutoPreco = c.Double(nullable: false),
                        ProdutoQuantidade = c.String(),
                        ProdutoImagem = c.String(),
                        CategoriaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProdutoId)
                .ForeignKey("dbo.Categorias", t => t.CategoriaId, cascadeDelete: true)
                .Index(t => t.CategoriaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtos", "CategoriaId", "dbo.Categorias");
            DropIndex("dbo.Produtos", new[] { "CategoriaId" });
            DropTable("dbo.Produtos");
            DropTable("dbo.Pessoas");
            DropTable("dbo.Categorias");
        }
    }
}
