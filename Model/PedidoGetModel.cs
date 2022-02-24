using System;
using System.Collections.Generic;

namespace API_Desafio_Angular.Model
{
    public class PedidoGetModel
    {
        public Guid IdPedido { get; set; }
        public DateTime DataPedido { get; set; }
        public decimal ValorTotal { get; set; }
        public ClienteGetModel Cliente { get; set; }
        public EnderecoGetModel EnderecoEntrega { get; set; }
        public List<ItemPedidoGetModel> ItensPedido { get; set; }

    }
}