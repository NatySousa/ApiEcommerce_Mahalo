using API_Desafio_Angular.Context;
using API_Desafio_Angular.Interfaces;
using API_Desafio_Angular.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API_Desafio_Angular.Configurations
{
    public static class RepositoryConfiguration
    {
        public static void ConfigureRepository(this IServiceCollection services, string connectionString)
        {
            #region Repositorios           

            //passar a connectionstring para a classe ApplicationDbContext criada para o EF
             services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            //mapear cada interface / classe do repositorio
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            services.AddTransient<IPedidoRepository, PedidoRepository>();
            services.AddTransient<IItemPedidoRepository, ItemPedidoRepository>();
            services.AddTransient<IEnderecoRepository, EnderecoRepository>();

            #endregion
        }
    }
}



