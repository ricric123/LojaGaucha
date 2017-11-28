using LojaGaucha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace LojaGaucha.DAL
{
    public class CategoriaDAO
    {
        private static Entities entities = new Entities();

        public static bool CadastrarCategoria(Categoria categoria)
        {
            try
            {
                entities.Categorias.Add(categoria);
                entities.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


        public static Categoria BuscarCategoriaPorId(int idCategoria)
        {
            return entities.Categorias.Find(idCategoria);
        }

    }
}