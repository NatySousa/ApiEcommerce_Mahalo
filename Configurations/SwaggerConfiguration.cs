using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace API_Desafio_Angular.Configurations
{
    public static class SwaggerConfiguration
    {
        public static void ConfigureSwagger(this IServiceCollection services)
        {

            #region Swagger

            services.AddSwaggerGen(
               swagger =>
               {
                   swagger.SwaggerDoc("v1", new OpenApiInfo
                   {
                       Title = "MAHALO - (Loja de Produtos)",
                       Description = "API REST desenvolvida por Natália Sousa",
                       Version = "v1",
                       Contact = new OpenApiContact
                       {
                           Name = "API_Projeto_Desafio_Angular",
                           Url = new Uri("https://th.bing.com/th/id/R.1cb58c88dd4228f4deb0a45e4dfb9349?rik=OMNZ0bEM%2fV8Q5A&pid=ImgRaw&r=0"),
                           Email = "mahalo@mahalo.com.br"
                       }
                   });

                   swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                   {
                       Name = "Authorization",
                       Type = SecuritySchemeType.ApiKey,
                       Scheme = "Bearer",
                       BearerFormat = "JWT",
                       In = ParameterLocation.Header,
                       Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                   });
                   swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });
               }
               );

            #endregion
        }
    }
}
