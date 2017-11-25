using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LojaGaucha.Models
{
    [Table("Categorias")]
    public class Categoria
    {
        [Key] // Notação para definir PK
        // [Required] - Notação para definir NOT NULL
        // [StringLength(100)] - Notação para deifinir tamanho do campo
        // [MaxLength(100)] - Notação para deifinir tamanho do campo
        // [MinLength(100)] - Notação para deifinir tamanho do campo
        public int CategoriaId { get; set; }
        public string CategoriaNome { get; set; }
    }
}