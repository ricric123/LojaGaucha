using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LojaGaucha.Models
{
    [Table("Pessoas")]
    public class Pessoa
    {
        [Key]
        public int PessoaId { get; set; }
        [Required]
        public string PessoaNome { get; set; }
        [Required]
        [EmailAddress]
        public string PessoaEmail { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string ClienteSenha { get; set; }
        [Required]
        public string ClienteCPF { get; set; }
        [Required]
        public string ClienteTelefone { get; set; }
        //parametro ("PessoaNivel") mostra a diferenca entre o cliente e funcionario
        //se o valor for 1 ele é funcionario; se o valor for 2 ele é o cliente
        //adicionar manualmente alguns funcionarios, na hora de cadastrar o cliente
        //fazer esse parametro receber 2-> (PessoaNivel = 2;)
        public int PessoaNivel { get; set; }
        [Display(Name = "Confirmação de Senha")]
        [Compare("ClienteSenha", ErrorMessage = "Os campos não coincidem")]
        [DataType(DataType.Password)]
        [NotMapped]
        public string ConfimacaoSenha { get; set; }
    }
}