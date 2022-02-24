using System;
using System.ComponentModel.DataAnnotations;

namespace API_Desafio_Angular.Model
{
    public class ClientePutModel
    {
        [Required(ErrorMessage = "Por favor, informe o id do cliente.")]
        public Guid IdCliente; 

        [Required(ErrorMessage = "Por favor, informe o nome do cliente.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe o cpf do cliente.")]
        public string Cpf { get; set; }
    }
}