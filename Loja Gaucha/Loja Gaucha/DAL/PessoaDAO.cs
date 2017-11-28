using LojaGaucha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace LojaGaucha.DAL
{
    public class PessoaDAO
    {
        private static Entities entities = new Entities();

        public static List<Pessoa> ListarUsuarios()
        {
            return entities.Pessoas.ToList();
        }

        public static bool CadastrarPessoa(Pessoa pessoa)
        {
            try
            {
                entities.Pessoas.Add(pessoa);
                entities.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        //####################################################################################################
        //#############################################################################################
        //        login
        //#########################################################################
        public static Pessoa BuscarPessoaPorEmailSenha(Pessoa pessoa)
        {
            return entities.Pessoas.
               FirstOrDefault(x => x.PessoaEmail.Equals(pessoa.PessoaEmail) &&
                x.ClienteSenha.Equals(pessoa.ClienteSenha));
        }
    }
}