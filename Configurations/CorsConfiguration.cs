using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace API_Desafio_Angular.Configurations
{
    public class CorsConfiguration
    {
        public static void ConfigureCors(IServiceCollection services)
        {
            //criando a politica de requisições para API..
            services.AddCors(
                s => s.AddPolicy("DefaultPolicy",
                builder =>
                {
                    //regras definidas..
                    builder.AllowAnyOrigin()//permitir requisições de qualquer origem
                           
                           .AllowAnyMethod()//permitir qualquer método (POST, PUT, DELETE, GET, etc)
                           
                           .AllowAnyHeader();//permitir envio de dados no HEADER da requisição
                    
                })
                );
        }

        public static void UseCors(IApplicationBuilder builder)
        {
            //definindo a politica padrão do projeto
            builder.UseCors("DefaultPolicy");
        }
    }
}

