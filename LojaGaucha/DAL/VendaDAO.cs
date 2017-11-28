using LojaGaucha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaGaucha.DAL
{
    public class VendaDAO
    {
        private static Entities entities = Singleton.Instance.Entities;

        public static bool CadastrarVenda(Venda venda)
        {
            try
            {
                entities.Vendas.Add(venda);
                entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}