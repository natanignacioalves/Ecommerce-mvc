using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        [Column("idCliente")]
        [Display(Name = "Código")]
        [Key]
        public int IdCliente { get; set; }

        [Column("nmCliente")]
        [Display(Name = "Nome")]
        [Required]
        public string NmCliente { get; set; }

        [Column("Cidade", TypeName = "text")]
        [Display(Name = "Cidade")]
        [Required]
        public string Cidade { get; set; }

        public Cliente()
        {
            NmCliente = string.Empty; // Inicializando a propriedade NmCliente com uma string vazia
            Cidade = string.Empty;
        }
    }
}
