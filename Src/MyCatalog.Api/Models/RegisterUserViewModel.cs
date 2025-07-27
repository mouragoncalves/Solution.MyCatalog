using System.ComponentModel.DataAnnotations;

namespace MyCatalog.Api.Models
{
    public class RegisterUserViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [EmailAddress(ErrorMessage = "O campo {0} deve ser um endereço de e-mail válido.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo {0} deve ter no mínimo {2} e no máximo {1} caracteres.", MinimumLength = 6)]
        public string Password { get; set; } = string.Empty;

        [Compare("Password", ErrorMessage = "A senha e a confirmação de senha não coincidem.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
