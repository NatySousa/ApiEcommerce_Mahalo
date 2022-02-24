using System;
using System.Collections.Generic;
using API_Desafio_Angular.Entities;
using API_Desafio_Angular.Interfaces;
using API_Desafio_Angular.Model;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_Desafio_Angular.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecosController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(EnderecoPostModel model, [FromServices] IEnderecoRepository enderecoRepository, [FromServices] IClienteRepository clienteRepository, [FromServices] IMapper mapper)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var endereco = mapper.Map<Endereco>(model);

                var cliente = clienteRepository.ObterPorEmail(User.Identity.Name); //buscar dados do cliente autenticado

                endereco.IdCliente = cliente.IdCliente;

                enderecoRepository.Inserir(endereco);

                return Ok("Endereço cadastrado com sucesso.");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }

        [HttpPut]
        public IActionResult Put(EnderecoPutModel model, [FromServices] IEnderecoRepository enderecoRepository, [FromServices] IClienteRepository clienteRepository, [FromServices] IMapper mapper)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var endereco = mapper.Map<Endereco>(model);

                var cliente = clienteRepository.ObterPorEmail(User.Identity.Name); //buscar dados do cliente autenticado

                endereco.IdCliente = cliente.IdCliente;

                enderecoRepository.Alterar(endereco); //atualizar os dados

                return Ok("Endereço atualizado com sucesso.");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id, [FromServices] IEnderecoRepository enderecoRepository)
        {
            try
            {
                var endereco = enderecoRepository.ObterPorId(id);
                enderecoRepository.Excluir(endereco);
                return Ok("Endereço excluido com sucesso.");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll([FromServices] IEnderecoRepository enderecoRepository, [FromServices] IClienteRepository clienteRepository, [FromServices] IMapper mapper)
        {
            try
            {
                var cliente = clienteRepository.ObterPorEmail(User.Identity.Name); //buscar dados do cliente autenticado

                var enderecos = enderecoRepository.ConsultarPorCliente(cliente.IdCliente); // consultar todos os endereços deste cliente

                var model = mapper.Map<List<EnderecoGetModel>>(enderecos);

                return Ok(model);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            return Ok();
        }
    }
}




