using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace API_Desafio_Angular.Model
{
    public class ProdutoPutModel
    {
        [Required(ErrorMessage = "Por favor, informe o id do produto.")]
        public Guid IdProduto { get; set; }

        [Required(ErrorMessage = "Por favor, informe o nome do produto.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe o preço do produto.")]
        public decimal? Preco { get; set; }

        [Required(ErrorMessage = "Por favor, informe a quantidade do produto.")]
        public int? Quantidade { get; set; }

        [Required(ErrorMessage = "Por favor, informe a unidade do produto.")]
        public string UnidadeMedida { get; set; }

        [Required(ErrorMessage = "Por favor, informe a foto do produto.")]
        public IFormFile Foto { get; set; }
    }
}
