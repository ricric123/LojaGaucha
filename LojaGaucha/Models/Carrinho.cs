using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LojaGaucha.Models
{
    [Table("Carrinhos")]
    public class Carrinho
    {
        [Key]
        public int IdCarrinho { get; set; }
        public List<ItemVenda> ItensVenda { get; set; }


    }
}