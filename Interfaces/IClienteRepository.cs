using API_Desafio_Angular.Entities;

namespace API_Desafio_Angular.Interfaces
{
    public interface IClienteRepository : IBaseRepository<Cliente>
    {
         Cliente ObterPorCpf(string cpf);
         Cliente ObterPorEmail(string email);
         Cliente ObterPorEmailESenha(string email, string senha);
    }
}