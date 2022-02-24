using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API_Desafio_Angular.Entities
{
    public class Pedido // Pedido = Carrinho de Compra
    {   [Key] //necessário pois o Entity não reconhece o GUID como chave primária
        public Guid IdPedido { get; set; }
        public DateTime DataPedido { get; set; }
        public decimal ValorTotal { get; set; }
        public Guid IdCliente { get; set; }
        public Guid? IdEndereco { get; set; }


        //Relacionamento -> TER-1
        public Cliente Cliente { get; set; }

        //Relacionamento -> TER-1
        public Endereco EnderecoEntrega { get; set; }

        //Relacionamento -> TER-MUITOS
        public List<ItemPedido> ItensPedido { get; set; }

    }
}