using System;

namespace API_Desafio_Angular.Model
{
    public class ProdutoGetModel
    {
        public Guid IdProduto { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public string Foto { get; set; }
    }
}