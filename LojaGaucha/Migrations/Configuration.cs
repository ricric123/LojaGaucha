namespace LojaGaucha.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LojaGaucha.Models.Entities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LojaGaucha.Models.Entities context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Pessoas.AddOrUpdate(
                new Models.Pessoa { PessoaEmail = "pedro@gmail.com", PessoaId = 2, PessoaNome = "Pedro", ClienteSenha = "senha123", ConfimacaoSenha = "senha123", ClienteCPF = "33333333333", ClienteTelefone = "(41)30299999"  }
               
                );
        }
    }
}
