using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LojaGaucha.Models
{

    [Table("Vendas")]
    public class Venda
    {
        [Key]
        public int VendaId { get; set; }
        public Pessoa Pessoa { get; set; }
        public int ClienteID { get; set; }
        public List<ItemVenda> Itens { get; set; }
        public string CarrinhoId { get; set; }

    }

}