using System;
using System.Collections.Generic;
using API_Desafio_Angular.Entities;

namespace API_Desafio_Angular.Interfaces
{
    public interface IEnderecoRepository : IBaseRepository<Endereco>
    {
         List<Endereco> ConsultarPorCliente(Guid idCliente);
    }
}