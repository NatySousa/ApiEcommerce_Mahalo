using API_Desafio_Angular.Context;
using API_Desafio_Angular.Entities;
using API_Desafio_Angular.Interfaces;

namespace API_Desafio_Angular.Repositories
{
   
    public class  ProdutoRepository: BaseRepository<Produto>, IProdutoRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public   ProdutoRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}