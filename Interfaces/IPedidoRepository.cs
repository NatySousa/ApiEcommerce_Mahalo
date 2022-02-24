using System;
using System.Collections.Generic;
using API_Desafio_Angular.Entities;

namespace API_Desafio_Angular.Interfaces
{
    public interface IPedidoRepository : IBaseRepository<Pedido>
    {
        void FinalizarPedido(Pedido pedido, List<ItemPedido> itensPedido);
        List<Pedido> ConsultarPorDatas(DateTime dataMin, DateTime dataMax);
        List<Pedido> ConsultarPorCliente(Guid idCliente);//Retorna todos os pedidos de um determinado cliente.Estes pedidos deverão vir com os dados de endereço e itens do pedido
    }
}
