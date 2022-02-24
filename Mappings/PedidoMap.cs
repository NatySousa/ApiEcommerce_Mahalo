using API_Desafio_Angular.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_Desafio_Angular.Mappings
{
    public class PedidoMap : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Pedido> builder)
        {
            
            builder.ToTable("Pedido"); //Nome da tabela

            builder.HasKey(p => p.IdPedido); // Chave primária

            // Demais campos da tabela

            builder.Property(p => p.IdPedido)
                .HasColumnName("IdPedido")
                .IsRequired();

            builder.Property(p => p.DataPedido)
                .HasColumnName("DataPedido")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(p => p.ValorTotal )
                .HasColumnName("ValorTotal")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(p => p.IdCliente)
                .HasColumnName("IdCliente")
                .IsRequired();

            builder.Property(p => p.IdEndereco)
               .HasColumnName("IdEndereco")
                .HasDefaultValue(null);
             


            //Mapeamento de relacionamento
            //Cardinalidade: 1 para muitos

            builder.HasOne(p => p.Cliente) //Pedido TEM-1 Cliente
                .WithMany(c => c.Pedidos) //Cliente TEM-MUITOS Pedidos
                .HasForeignKey(p => p.IdCliente); //Chave Estrangeira


            //Mapeamento de relacionamento
            //Cardinalidade: 1 para muitos

            builder.HasOne(p => p.EnderecoEntrega) //Pedido TEM-1 Endereço
                .WithMany(e => e.Pedidos) //Endereço TEM-MUITOS Pedidos
                .HasForeignKey(p => p.IdEndereco); //Chave Estrangeira
        }
    }
}