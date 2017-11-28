namespace LojaGaucha.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vendaV3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Vendas", "PessoaId", "dbo.Pessoas");
            DropIndex("dbo.Vendas", new[] { "PessoaId" });
            RenameColumn(table: "dbo.Vendas", name: "PessoaId", newName: "Pessoa_PessoaId");
            AlterColumn("dbo.Vendas", "Pessoa_PessoaId", c => c.Int());
            CreateIndex("dbo.Vendas", "Pessoa_PessoaId");
            AddForeignKey("dbo.Vendas", "Pessoa_PessoaId", "dbo.Pessoas", "PessoaId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vendas", "Pessoa_PessoaId", "dbo.Pessoas");
            DropIndex("dbo.Vendas", new[] { "Pessoa_PessoaId" });
            AlterColumn("dbo.Vendas", "Pessoa_PessoaId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Vendas", name: "Pessoa_PessoaId", newName: "PessoaId");
            CreateIndex("dbo.Vendas", "PessoaId");
            AddForeignKey("dbo.Vendas", "PessoaId", "dbo.Pessoas", "PessoaId", cascadeDelete: true);
        }
    }
}
