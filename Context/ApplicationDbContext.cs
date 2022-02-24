using API_Desafio_Angular.Entities;
using API_Desafio_Angular.Mappings;
using Microsoft.EntityFrameworkCore;

namespace API_Desafio_Angular.Context
{
    public class ApplicationDbContext : DbContext
    {
         //construtor tem que ser public
        public ApplicationDbContext(DbContextOptions options) : base(options) 
        {
        }

        //criando atributo genérico DbSet<> para cada entidade que eu quero mapear no banco CRUD
         public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<ItemPedido> ItemPedido { get; set; } //É atarvés desse DbSet que vai ser possível fazer as alterações no banco p/pedidos
        public DbSet<Endereco> Endereco { get; set; }

        //Sobrescrever cada classe de mapeamento utilizado para registrar cada classe de mapeamento
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //adicionando cada classe de mapeamento

            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new PedidoMap());
            modelBuilder.ApplyConfiguration(new ItemPedidoMap());
            modelBuilder.ApplyConfiguration(new EnderecoMap());
        }
    }
}