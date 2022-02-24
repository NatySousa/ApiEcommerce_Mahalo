using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API_Desafio_Angular.Entities
{
    public class Produto
    {   [Key] //necessário pois o Entity não reconhece o GUID como chave primária
        public Guid IdProduto { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public string UnidadeMedida { get; set; }
        public string Foto { get; set; }

        //Relacionamento -> TER-MUITOS
        public List<ItemPedido> ItensPedido { get; set; }
    }
}