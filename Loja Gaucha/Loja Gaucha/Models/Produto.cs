using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LojaGaucha.Models
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }
        [Required]
        [StringLength(100)]
        public string ProdutoNome { get; set; }
        [Required]
        [StringLength(1000)]
        public string ProdutoDescricao { get; set; }
        public double ProdutoPreco { get; set; }
        public int ProdutoQuantidade { get; set; }
        public string ProdutoImagem { get; set; }
        public virtual Categoria Categoria { get; set; }
        public int CategoriaId { get; set; }
        public string Peso { get; set; }
    }
}