using System;
using System.Collections.Generic;
using System.Linq;
using API_Desafio_Angular.Context;
using API_Desafio_Angular.Entities;
using API_Desafio_Angular.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_Desafio_Angular.Repositories
{
    public class ItemPedidoRepository: BaseRepository<ItemPedido>, IItemPedidoRepository
    {
          private readonly ApplicationDbContext _dbContext;

        public  ItemPedidoRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public List<ItemPedido> ConsultarPorPedido(Guid idPedido)
        {
            return _dbContext.ItemPedido // cada item de pedido que retornar vai vir também os dados do produto 
            .Include(p=> p.Produto) // Join
            .Where(i=> i.IdPedido.Equals(idPedido))
            .OrderByDescending(i=> i.QuantidadeProduto)
            .ToList();

        }
    }
}