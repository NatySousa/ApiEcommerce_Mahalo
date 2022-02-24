using System;
using System.ComponentModel.DataAnnotations;

namespace API_Desafio_Angular.Entities
{
    public class ItemPedido // Carrinho de Compras
    {   
        [Key] //necessário pois o Entity não reconhece o GUID como chave primária
        public Guid IdItemPedido { get; set; }
        public Guid IdPedido { get; set; } //Pedido = Compra
        public Guid IdProduto { get; set; }
        public int QuantidadeProduto { get; set; }
        public float ValorUnitarioProduto { get; set; }
        public float ValorTotalItem { get; set; }

        //Relacionamentos
        public Pedido Pedido { get; set; }
        public Produto Produto { get; set; }  
    }
}