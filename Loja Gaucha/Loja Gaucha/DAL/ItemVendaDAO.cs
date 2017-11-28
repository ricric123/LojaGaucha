using LojaGaucha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaGaucha.DAL
{
    public class ItemVendaDAO
    {
        private static Entities entities = Singleton.Instance.Entities;
        private static ItemVenda itemVenda = new ItemVenda();



        public static bool AdicionarItemVenda(int idProduto)
        {
            itemVenda = BuscarProdutoNoCarrinho(idProduto);
            if (itemVenda == null)
            {
                #region
                itemVenda = new ItemVenda();
                itemVenda.ItemVendaProduto = ProdutoDAO.BuscarProdutoPorId(idProduto);
                itemVenda.ProdutoId = idProduto;
                itemVenda.ItemVendaPreco = itemVenda.ItemVendaProduto.ProdutoPreco;
                itemVenda.ItemVendaQuantidade = 1;
                itemVenda.DataDaAdicao = DateTime.Now;
                itemVenda.IdCarrinho = RetornarCarrinhoId();
                //TEMQ "LIMPAR" A VARIAVEL PARA PODER GRAVAR NO BANCO NAO SEI O DIABO PQ
                itemVenda.ItemVendaProduto = null;

                try
                {
                    ProdutoDAO.DiminuirQuantidadeDeProdutoAoAdicionaloAoCarrinho(idProduto, itemVenda.ItemVendaQuantidade);
                    entities.ItensVenda.Add(itemVenda);
                    entities.SaveChanges();
                    return false;
                }
                catch (Exception)
                {
                    return true;
                }
                #endregion
            }
            else
            {
                itemVenda.ItemVendaQuantidade++;
                ProdutoDAO.DiminuirQuantidadeDeProdutoAoAdicionaloAoCarrinho(idProduto,itemVenda.ItemVendaQuantidade);
                entities.SaveChanges();
                return true;
            }
        }

        public static bool RemoverItemVenda(int idProduto)
        {
            itemVenda = BuscarProdutoNoCarrinho(idProduto);
            if (itemVenda.ItemVendaQuantidade == 1)
            {
                try
                {
                    entities.ItensVenda.Remove(itemVenda);
                    entities.SaveChanges();
                    return false;
                }
                catch (Exception)
                {
                    return true;
                }
            }
            else
            {
                itemVenda.ItemVendaQuantidade--;
                entities.SaveChanges();
                return true;
            }
        }

        public static string RetornarCarrinhoId()
        {
            if (HttpContext.Current.Session["CarrinhoId"] == null)
            {
                Guid guid = Guid.NewGuid();
                HttpContext.Current.Session["CarrinhoId"] = guid.ToString();
            }
            return HttpContext.Current.Session["CarrinhoId"].ToString();
        }

        public static ItemVenda BuscarProdutoNoCarrinho(int idProduto)
        {
            string idCarrinho = RetornarCarrinhoId();

            return entities.ItensVenda.
                FirstOrDefault(x => x.ProdutoId == idProduto
                && x.IdCarrinho.Equals(idCarrinho));
        }

        public static List<ItemVenda> RetornarItensDoCarrinho()
        {
            string idCarrinho = RetornarCarrinhoId();

            return entities.ItensVenda.
                Where(x => x.IdCarrinho.Equals(idCarrinho)).
                ToList();
        }


        public static double RetornarValorTotalDoCarrinho()
        {
            return RetornarItensDoCarrinho().
                Sum(x => x.ItemVendaPreco * x.ItemVendaQuantidade);
        }

        public static int RetornarQuantidadeDoCarrinho()
        {
            return RetornarItensDoCarrinho().
                Sum(x => x.ItemVendaQuantidade);
        }

        public static void ZerarCarrinho()
        {
            HttpContext.Current.Session["CarrinhoId"] = null;
        }
    }
}