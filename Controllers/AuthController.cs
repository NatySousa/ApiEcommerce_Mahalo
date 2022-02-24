using System;
using System.Collections.Generic;
using API_Desafio_Angular.Interfaces;
using API_Desafio_Angular.Model;
using API_Desafio_Angular.Security;
using API_Desafio_Angular.Util;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API_Desafio_Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(AuthPostModel model,
            [FromServices] IClienteRepository clienteRepository,
            [FromServices] IEnderecoRepository enderecoRepository,
            [FromServices] TokenService tokenService,
            [FromServices] IMapper mapper)
        {
            try
            {
                //buscar o cliente na base atraves do email e da senha..
                var cliente = clienteRepository.ObterPorEmailESenha(model.Email, Criptografia.CriarHash(model.Senha));

                //verificar se o cliente foi encontrado..
                if (cliente != null)
                {
                    var enderecos = enderecoRepository.ConsultarPorCliente(cliente.IdCliente); //consultar os endereços do cliente

                    var clienteModel = mapper.Map<ClienteGetModel>(cliente);//usando o AutoMapper p/trenferir os dados p/model

                    clienteModel.Enderecos = mapper.Map<List<EnderecoGetModel>>(enderecos);

                    //tempo de expiração do token em horas
                    var tempoExpiracaoToken = 24; //1 dia

                    //objeto para retornar os dados de resposta
                    //de sucesso do método..
                    var result = new
                    {
                        Mensagem = "Autenticação realizada com sucesso.",
                        AccessToken = tokenService.GenerateToken(cliente.Email, tempoExpiracaoToken),
                        ExpiraEm = DateTime.Now.AddHours(tempoExpiracaoToken),
                        Cliente = clienteModel
                        
                    };

                    return Ok(result);
                }
                else
                {
                    //UNAUTHORIZED (HTTP 401)
                    return Unauthorized("Acesso negado.");
                }
            }
            catch (Exception e)
            {
                //INTERNAL SERVER ERROR (HTTP 500)
                return StatusCode(500, e.Message);
            }
        }
    }
}