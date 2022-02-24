using System;
using System.Collections.Generic;
using System.Linq;
using API_Desafio_Angular.Context;
using API_Desafio_Angular.Entities;
using API_Desafio_Angular.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_Desafio_Angular.Repositories
{
    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PedidoRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Pedido> ConsultarPorDatas(DateTime dataMin, DateTime dataMax)
        {
            return _dbContext.Pedido
                .Where(p => p.DataPedido >= dataMin
                          && p.DataPedido <= dataMax)
                .ToList();
        }


        public void FinalizarPedido(Pedido pedido, List<ItemPedido> itensPedido)
        {
            //abrir uma transação no banco de dados
            var transaction = _dbContext.Database.BeginTransaction();

            try
            {
                //primeiro, iremos gravar no banco de dados o pedido..
                _dbContext.Pedido.Add(pedido);
                _dbContext.SaveChanges();

                //segundo, iremos gravar os itens do pedido..
                foreach (var item in itensPedido)
                {
                    //cada item de pedido deve estar associado ao pedido..
                    //este vinculo deve ser feito por meio de foreign key
                    item.IdPedido = pedido.IdPedido;

                    //salvar o item do pedido no banco de dados
                    _dbContext.ItemPedido.Add(item);
                    _dbContext.SaveChanges();

                     var produto = _dbContext.Produto.Find(item.IdProduto);
                    produto.Quantidade = produto.Quantidade - item.QuantidadeProduto;

                    _dbContext.Produto.Update(produto);
                    _dbContext.SaveChanges();
                }

                //faz o COMMIT (confirma) da transação
                transaction.Commit();
            }
            catch (Exception e)
            {
                //desfazer as operações realizadas na transação
                transaction.Rollback();

                //retornar um erro para a API..
                throw new Exception("Erro ao cadastrar o Pedido: " + e.Message);
            }
        }


        public List<Pedido> ConsultarPorCliente(Guid idCliente)
        {
            return _dbContext.Pedido //Todo pedido tem 1 cliente e esse cliente tem pelo menos 1 endereço, para a consulta trazer esses dados eu preciso fazer o Join, colocar o Include
           .Include(p=> p.Cliente) //Join
           .Include(p=> p.EnderecoEntrega)//Join
           .Where(p=> p.IdCliente.Equals(idCliente))
           .OrderByDescending(p=> p.DataPedido)
           .ToList();
        }
    }
}
