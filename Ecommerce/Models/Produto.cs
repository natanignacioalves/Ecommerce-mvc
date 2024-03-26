using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Models
{
    [Table("Produtos")]
    public class Produto
    {
        [Column("idProduto")]
        [Display(Name ="Código")]
        [Key]
        public int IdProduto { get; set; }

        [Column("dscProduto")]
        [Display(Name = "Descrição")]
        [Required]
        public  String DscProduto { get; set; }

        [Column("vlrUnitario")]
        [Display(Name = "Valor")]
        public float VlrUnitario { get; set; }

        public Produto()
        {
            DscProduto = string.Empty; // Inicializando a propriedade DscProduto com uma string vazia
        }
    }
}
