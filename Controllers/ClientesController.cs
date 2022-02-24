using System;
using System.Collections.Generic;
using API_Desafio_Angular.Entities;
using API_Desafio_Angular.Interfaces;
using API_Desafio_Angular.Model;
using API_Desafio_Angular.Util;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API_Desafio_Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
               [HttpPost]
        public IActionResult Post(ClientePostModel model, 
            [FromServices] IClienteRepository clienteRepository, 
            [FromServices] IMapper mapper)
        {
            try
            {
                //pesquisar o cliente no banco de dados pelo email..
                //verificar se o cliente foi encontrado
                if(clienteRepository.ObterPorEmail(model.Email) != null)
                {
                    return UnprocessableEntity($"O email {model.Email} informado já encontra-se cadastrado.");
                }
                //pesquisar o cliente no banco de dados pelo cpf..
                //verificar se o cliente foi encontrado
                else if (clienteRepository.ObterPorCpf(model.Cpf) != null)
                {
                    return UnprocessableEntity($"O CPF {model.Cpf} informado já encontra-se cadastrado.");
                }
                else
                {
                    var cliente = mapper.Map<Cliente>(model);
                    cliente.Senha = Criptografia.CriarHash(model.Senha);
                    clienteRepository.Inserir(cliente);

                    return Ok("Cliente cadastrado com sucesso.");
                }
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(ClientePutModel model,
            [FromServices] IClienteRepository clienteRepository, 
            [FromServices] IMapper mapper)
        {
            try
            {
                if(clienteRepository.ObterPorId(model.IdCliente) == null)
                {
                    return UnprocessableEntity("Cliente não encontrado.");
                }

                var cliente = mapper.Map<Cliente>(model);

                clienteRepository.Alterar(cliente);
                return Ok("Cliente atualizado com sucesso.");
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{idCliente}")]
        public IActionResult Delete(Guid idCliente, 
            [FromServices] IClienteRepository clienteRepository)
        {
            try
            {
                var cliente = clienteRepository.ObterPorId(idCliente);

                if (cliente == null)
                {

                    return UnprocessableEntity("Cliente não encontrado.");
                }

                //excluindo o cliente
                clienteRepository.Excluir(cliente);
                return Ok("Cliente excluído com sucesso.");
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll(
            [FromServices] IClienteRepository clienteRepository, 
            [FromServices] IMapper mapper)
        {
            try
            {
                var clientes = clienteRepository.Consultar();
                var lista = mapper.Map<List<ClienteGetModel>>(clientes);

                return Ok(lista);
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{idCliente}")]
        public IActionResult GetById(Guid idCliente, 
            [FromServices] IClienteRepository clienteRepository, 
            [FromServices] IMapper mapper)
        {
            try
            {
                var cliente = clienteRepository.ObterPorId(idCliente);

                if(cliente == null)
                {
                    return NoContent();
                }

                var model = mapper.Map<ClienteGetModel>(cliente);
                return Ok(model);
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }

    }

}


