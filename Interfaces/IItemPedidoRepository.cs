using System;
using System.Collections.Generic;
using API_Desafio_Angular.Entities;

namespace API_Desafio_Angular.Interfaces
{
    public interface IItemPedidoRepository : IBaseRepository<ItemPedido>
    {
         List<ItemPedido> ConsultarPorPedido(Guid idPedido);
    }
}