using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EcommerceIdeia.Models
{
    [Table("Pedido")]
    public class Pedido
    {
        [Key]
        public int idPedido { get; set; }

        [RegularExpression(@"^\d+(\.|,)\d{0,2}$")]
        [Display(Name = "Valor Total")]
        public decimal valorTotal { get; set; }

        public List<Carrinho> Carrinhos { get; set; }

        public string CarrinhoGuid { get; set; }
    }
}