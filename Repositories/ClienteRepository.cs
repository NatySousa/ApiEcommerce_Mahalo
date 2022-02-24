using System.Linq;
using API_Desafio_Angular.Context;
using API_Desafio_Angular.Entities;
using API_Desafio_Angular.Interfaces;

namespace API_Desafio_Angular.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
         private readonly ApplicationDbContext _dbContext;

        public ClienteRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Cliente ObterPorCpf(string cpf)
        {
             return  _dbContext.Cliente
            .FirstOrDefault(c => c.Cpf.Equals(cpf));
        }

        public Cliente ObterPorEmail(string email)
        {
           return  _dbContext.Cliente
                    .FirstOrDefault(c => c.Email.Equals(email));
        }

        public Cliente ObterPorEmailESenha(string email, string senha)
        {
             return  _dbContext.Cliente
             .FirstOrDefault(c => c.Email.Equals(email) && c.Senha.Equals(senha)); 
        }
    }
}