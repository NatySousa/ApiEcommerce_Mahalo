using System;
using API_Desafio_Angular.Entities;
using API_Desafio_Angular.Model;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace API_Desafio_Angular.Configurations
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration() //Configurando o AutoMapper para fazer a transferencia de dados get,post,put das classes
        {
            #region Requests Post/Put 
            CreateMap<ClientePostModel, Cliente>()
                .AfterMap((scr, dest) =>
                {
                    dest.IdCliente = Guid.NewGuid();
                });

            CreateMap<ClientePutModel, Cliente>();

            CreateMap<EnderecoPostModel, Endereco>()
                .AfterMap((scr, dest) =>
                {
                    dest.IdEndereco = Guid.NewGuid();
                });

            CreateMap<EnderecoPutModel, Endereco>();

            CreateMap<ProdutoPostModel, Produto>()
                .AfterMap((scr, dest) =>
                {
                    dest.IdProduto = Guid.NewGuid();
                });

            CreateMap<ProdutoPutModel, Produto>();
            
            CreateMap<PedidoPostModel, Pedido>().AfterMap((src, dest) =>
            {
                dest.IdPedido = Guid.NewGuid();
            });
            CreateMap<ItemPedidoPostModel, ItemPedido>().AfterMap((src, dest) =>
           {
               dest.IdItemPedido = Guid.NewGuid(); ;
           });
            #endregion

            #region Responses (Get)

            CreateMap<Cliente, ClienteGetModel>();

            CreateMap<Endereco, EnderecoGetModel>();

            CreateMap<Produto, ProdutoGetModel>();

            CreateMap<Pedido,PedidoGetModel>();

            CreateMap<ItemPedido, ItemPedidoGetModel>();

            #endregion
        }

        // método para adicionar o automapper no container da classe startup
        public static void Configure(IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}