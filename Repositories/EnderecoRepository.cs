using System;
using System.Collections.Generic;
using System.Linq;
using API_Desafio_Angular.Context;
using API_Desafio_Angular.Entities;
using API_Desafio_Angular.Interfaces;

namespace API_Desafio_Angular.Repositories
{
    public class EnderecoRepository : BaseRepository<Endereco>, IEnderecoRepository
    {
          private readonly ApplicationDbContext _dbContext;

        public EnderecoRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Endereco> ConsultarPorCliente(Guid idCliente)
        {
            return _dbContext.Endereco.Where(e => e.IdCliente.Equals(idCliente)).ToList();
        }
    }
}