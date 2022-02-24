using System;
using System.Collections.Generic;
using API_Desafio_Angular.Entities;
using API_Desafio_Angular.Interfaces;
using API_Desafio_Angular.Model;
using API_Desafio_Angular.Util;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace API_Desafio_Angular.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromForm] ProdutoPostModel model,
            [FromServices] IProdutoRepository produtoRepository, [FromServices] IMapper mapper)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var produto = mapper.Map<Produto>(model);
                produto.Foto = UploadImagem.Image(model.Foto);

                produtoRepository.Inserir(produto);

                return Ok("Produto cadastrado com sucesso.");


            }
            catch (Exception e)
            {
                //retornar erro (HTTP 500 - INTERNAL SERVER ERROR)
                return StatusCode(500, e.Message);
            }
        }


        [HttpPut]
        public IActionResult Put([FromForm] ProdutoPutModel model,
            [FromServices] IProdutoRepository produtoRepository, [FromServices] IMapper mapper)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                if (produtoRepository.ObterPorId(model.IdProduto) == null) //verifica se o produto não existe na base de dados
                {
                    return UnprocessableEntity("Produto não encontrado.");
                }

                var produto = mapper.Map<Produto>(model);
                produto.Foto = UploadImagem.Image(model.Foto);

                produtoRepository.Alterar(produto);

                return Ok("Produto cadastrado com sucesso.");


            }
            catch (Exception e)
            {
                //RETORNAR ERRO HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{idProduto}")]
        public IActionResult Delete(Guid idProduto,
            [FromServices] IProdutoRepository produtoRepository)
        {
            try
            {
                var produto = produtoRepository.ObterPorId(idProduto);

                if (produto != null)
                {
                    produtoRepository.Excluir(produto);
                    return Ok("Produto excluído com sucesso.");
                }
                else
                {
                    //RETORNAR ERRO HTTP 422 (UNPROCESSABLE ENTITY)
                    return UnprocessableEntity("Produto não encontrado.");
                }
            }
            catch (Exception e)
            {
                //RETORNAR ERRO HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, e.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAll([FromServices] IProdutoRepository produtoRepository, [FromServices] IMapper mapper)
        {
            try
            {
                var produtos = produtoRepository.Consultar();

                var lista = mapper.Map<List<ProdutoGetModel>>(produtos);

                // foreach (var item in lista)
                // {
                //     byte[] imageArray = System.IO.File.ReadAllBytes(item.Foto);
                //     string base64ImageRepresentation = Convert.ToBase64String(imageArray);
                //     item.Foto = base64ImageRepresentation;
                // }


                return Ok(lista);
            }
            catch (Exception e)
            {
                //RETORNAR ERRO HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, e.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet("{idProduto}")]
        public IActionResult GetById(Guid idProduto,
            [FromServices] IProdutoRepository produtoRepository, [FromServices] IMapper mapper)
        {
            try
            {
                //buscando 1 produto no banco de dados atraves do ID..
                var produto = produtoRepository.ObterPorId(idProduto);

                //verificar se o produto foi encontrado..
                if (produto == null)
                {
                    return NoContent();
                }
                var model = mapper.Map<ProdutoGetModel>(produto);

                // byte[] imageArray = System.IO.File.ReadAllBytes(model.Foto);
                // string base64ImageRepresentation = Convert.ToBase64String(imageArray);
                // model.Foto = base64ImageRepresentation;

                return Ok(model);

            }
            catch (Exception e)
            {
                //RETORNAR ERRO HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, e.Message);
            }
        }
    }
}
