using System.ComponentModel.DataAnnotations;

namespace API_Desafio_Angular.Model
{
    public class EnderecoPostModel
    {
        [Required(ErrorMessage = " Por favor, informe o logradouro.")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = " Por favor, informe o número.")]
        public string Numero { get; set; }

        [Required(ErrorMessage = " Por favor, informe o Complemento.")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = " Por favor, informe o bairro.")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = " Por favor, informe a cidade.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = " Por favor, informe o estado.")]
        public string Estado { get; set; }

        [Required(ErrorMessage = " Por favor, informe o cep.")]
        public string Cep { get; set; }

    }
}