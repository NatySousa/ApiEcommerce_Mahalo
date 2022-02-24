using System.ComponentModel.DataAnnotations;

namespace API_Desafio_Angular.Model
{
    public class AuthPostModel
    {
        [EmailAddress(ErrorMessage = "Email inválido.")]
         
        [Required(ErrorMessage = "Por favor, informe o email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Por favor, informe a senha")]
        public string Senha { get; set; }

    }
}