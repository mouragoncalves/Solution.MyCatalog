using System.ComponentModel.DataAnnotations;

namespace MyCatalog.Api.Models
{
    public class ProdutoModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O {0} é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O {0} deve ser maior que zero.")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "A {0} é obrigatória.")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "A {0} é obrigatória.")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "A {0} deve ter entre {1} e {2} caracteres.")]
        public string Descricao { get; set; } = string.Empty;
    }
}
