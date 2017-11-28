using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace LojaGaucha.Models
{
    [Table("ItensVenda")]
    public class ItemVenda
    {
        [Key]
        public int ItemVendaId { get; set; }
        public Produto ItemVendaProduto { get; set; }
        public int ProdutoId { get; set; }
        public double ItemVendaPreco { get; set; }
        public int ItemVendaQuantidade { get; set; }
        public string IdCarrinho { get; set; }
        public DateTime DataDaAdicao { get; set; }
    }
}