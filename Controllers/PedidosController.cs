using System;
using System.Collections.Generic;
using System.Linq;
using API_Desafio_Angular.Entities;
using API_Desafio_Angular.Interfaces;
using API_Desafio_Angular.Model;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_Desafio_Angular.Controllers
{
    [Authorize] //somente usuários cadastrados
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {

        [HttpPost]
        public IActionResult Post(PedidoPostModel model,
            [FromServices] IPedidoRepository pedidoRepository,
            [FromServices] IClienteRepository clienteRepository,
            [FromServices] IEnderecoRepository enderecoRepository,
            [FromServices] IMapper mapper)
        {
            try
            {
                var pedido = mapper.Map<Pedido>(model);


                var cliente = clienteRepository.ObterPorEmail(User.Identity.Name); //capturar o cliente autenticado atraves do email

                pedido.IdCliente = cliente.IdCliente;

                var enderecos = enderecoRepository.ConsultarPorCliente(cliente.IdCliente);//capturar todos os endereços cadastrados do cliente

                if (enderecos.FirstOrDefault(e => e.IdEndereco.Equals(model.IdEndereco)) == null) //verificando se o endereço de entrega não é um dos endereços do cliente..
                {
                    return UnprocessableEntity("O Endereço de entrega é inválido.Verifique os endereços do cliente.");
                }

                //associar o endereço de entrega do pedido
                pedido.IdEndereco = model.IdEndereco;
                pedido.DataPedido = DateTime.Now;

                //capturar os dados dos itens do pedido..
                var itensPedido = mapper.Map<List<ItemPedido>>(model.ItensPedido);

                //gravar o pedido..
                pedidoRepository.FinalizarPedido(pedido, itensPedido);

                return Ok("Pedido realizado com sucesso.");
            }
            catch (Exception e)
            {
                //HTTP 500 - INTERNAL SERVER ERROR
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult Get(
            [FromServices] IPedidoRepository pedidoRepository,
            [FromServices] IItemPedidoRepository itemPedidoRepository,
            [FromServices] IClienteRepository clienteRepository,
            [FromServices] IMapper mapper)
        {

            try
            {
                //buscar o cliente autenticado
                var cliente = clienteRepository.ObterPorEmail(User.Identity.Name);

                //buscar os pedidos do cliente
                var pedidos = pedidoRepository.ConsultarPorCliente(cliente.IdCliente);
                var model = mapper.Map<List<PedidoGetModel>>(pedidos);

                //percorrendo os pedidos
                foreach (var pedido in model)
                {
                    //buscando os itens do pedido
                    var itensPedido = itemPedidoRepository.ConsultarPorPedido(pedido.IdPedido);
                    pedido.ItensPedido = mapper.Map<List<ItemPedidoGetModel>>(itensPedido);
                }

                return Ok(model);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
