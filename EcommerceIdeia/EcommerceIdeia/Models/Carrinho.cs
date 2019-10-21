using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EcommerceIdeia.Models
{
    [Table("Carrinho")]
    public class Carrinho
    {
        [Key]
        public int idCarrinho { get; set; }

        public string carrinhoGuid { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Nome do produto")]
        public Produto Produto { get; set; }

        public Pedido Pedido { get; set; }


        [RegularExpression(@"^\d+(\.|,)\d{0,2}$")]
        [Display(Name = "Valor")]
        public decimal valor { get; set; }

        [Display(Name = "Quantidade")]
        public int quantidade { get; set; }
    }
}