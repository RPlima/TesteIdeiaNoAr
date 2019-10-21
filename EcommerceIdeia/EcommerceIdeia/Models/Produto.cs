using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EcommerceIdeia.Models
{
    [Table("Produto")]
    public class Produto
    {
        [Key]
        public int idProduto { get; set; }

        
        [Required(ErrorMessage = "O campo nome é obrigatório!")]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Nome do Produto")]
        [MaxLength(45, ErrorMessage = "O campo deve ter no máximo 45 caracteres")]
        public string nomeProduto { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório!")]
        [RegularExpression(@"^\d+(\.|,)\d{0,2}$")]
        [Display(Name = "Preço")]
        public decimal preco { get; set; }
    }
}