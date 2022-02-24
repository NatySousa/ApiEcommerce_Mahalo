using System;
using System.Collections.Generic;

namespace API_Desafio_Angular.Model
{
    public class PedidoPostModel
    {
        public DateTime DataPedido { get; set; }
        public decimal ValorTotal { get; set; }
        public Guid IdEndereco { get; set; } //captura do endereço de entrega do pedido. A Api verifica se o endereço pertence ao cliente autenticado
        public List<ItemPedidoPostModel> ItensPedido { get; set; }
    }
}