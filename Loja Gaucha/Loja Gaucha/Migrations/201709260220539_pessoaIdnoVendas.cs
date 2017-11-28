namespace LojaGaucha.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pessoaIdnoVendas : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Vendas", "Pessoa_PessoaId", "dbo.Pessoas");
            DropIndex("dbo.Vendas", new[] { "Pessoa_PessoaId" });
            RenameColumn(table: "dbo.Vendas", name: "Pessoa_PessoaId", newName: "PessoaId");
            AlterColumn("dbo.Vendas", "PessoaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Vendas", "PessoaId");
            AddForeignKey("dbo.Vendas", "PessoaId", "dbo.Pessoas", "PessoaId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vendas", "PessoaId", "dbo.Pessoas");
            DropIndex("dbo.Vendas", new[] { "PessoaId" });
            AlterColumn("dbo.Vendas", "PessoaId", c => c.Int());
            RenameColumn(table: "dbo.Vendas", name: "PessoaId", newName: "Pessoa_PessoaId");
            CreateIndex("dbo.Vendas", "Pessoa_PessoaId");
            AddForeignKey("dbo.Vendas", "Pessoa_PessoaId", "dbo.Pessoas", "PessoaId");
        }
    }
}
