using LojaGaucha.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LojaGaucha.DAL
{
    public class ProdutoDAO
    {

        private static Entities entities = new Entities();

        public static List<Produto> RetornarProdutos()
        {
            return entities.Produtos.ToList();
        }


        public static List<Produto> BuscarProdutosPorCategoria(int idCategoria)
        {
            return entities.Produtos.Where
                (x => x.Categoria.CategoriaId == idCategoria).ToList();
        }

        public static Produto BuscarProdutoPorId(int idProduto)
        {
            //return entities.Produtos.
            //FirstOrDefault(x => x.ProdutoId == idProduto);

            //Find busca somente pela chave primária
            return entities.Produtos.Find(idProduto);
        }
        //FUNCAO PRA REMOVER O NUME
        public static bool DiminuirQuantidadeDeProdutoAoAdicionaloAoCarrinho(int idProduto, int itemVendaQuantidade)
        {
            try
            {
                Produto produto = new Produto();
                produto = BuscarProdutoPorId(idProduto);
                produto.ProdutoQuantidade = produto.ProdutoQuantidade - itemVendaQuantidade;
                entities.Entry(produto).State = EntityState.Modified;
                entities.SaveChanges();
                return true;
            }catch(Exception e)
            {
                return false;
            }
        }
        //FUNCAO PRA REMOVER O NUME
        public static bool AumentarQuantidadeDeProdutoAoAdicionaloAoCarrinho(int idProduto, int ProdutoQuantidade)
        {
            try
            {
                Produto produto = new Produto();
                produto = BuscarProdutoPorId(idProduto);
                produto.ProdutoQuantidade = produto.ProdutoQuantidade + ProdutoQuantidade;
                entities.Entry(produto).State = EntityState.Modified;
                entities.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


        public static bool CadastrarProduto(Produto produto)
        {
            try
            {
                entities.Produtos.Add(produto);
                entities.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}