
using System;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace API_Desafio_Angular.Util
{
    public static class UploadImagem
    {
        public static string Image(IFormFile imagem)
        {
            if (imagem == null)
            {
                return string.Empty;
            }
            var guid = Guid.NewGuid();

            var path = Path.Combine("C:\\GFT\\Projetos_Angular\\CursoAngular\\src\\assets\\", guid + ".jpg");

            if (imagem != null)
            {
                var fileStram = new FileStream(path, FileMode.Create);
                imagem.CopyTo(fileStram);
            }

            return  guid + ".jpg";
        }
    }
}