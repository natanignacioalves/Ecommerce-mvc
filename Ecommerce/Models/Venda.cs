using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Models
{
    [Table("Vendas")]
    public class Venda
    {
        [Column("idVenda")]
        [Display(Name = "idVenda")]
        [Key]
        public int IdVenda { get; set; }

        [Column( "idCliente")]
        [Display(Name = "idCliente")]
        public int IdCliente { get; set; }

        [Column("idProduto")]
        [Display(Name = "idProduto")]
        public int IdProduto { get; set; }

        [Column("qtdVenda")]
        [Display(Name = "Quantidade")]
        public int QtdVenda { get; set; }

        [Column("vlrUnitarioVenda")]
        [Display(Name = "Valor Unitário")]
        public int VlrUnitarioVenda { get; set; }

        [Column("dthVenda")]
        [Display(Name = "Data Venda")]
        public DateTime DthVenda { get; set; }

        [Column("vlrTotalVenda")]
        [Display(Name = "Valor Total")]
        public float VlrTotalVenda { get; set; }

        public Venda()
        {
            DthVenda = DateTime.Now; // Inicializando a propriedade DthVenda com a data e hora atual
        }

    }
}
