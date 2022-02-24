using API_Desafio_Angular.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_Desafio_Angular.Mappings
{
    public class ItemPedidoMap : IEntityTypeConfiguration<ItemPedido>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ItemPedido> builder)
        {
           
            builder.ToTable("ItemPedido"); //nome da tabela no banco de dados

            //chave primária
            builder.HasKey(i => i.IdItemPedido);//chave primária

            //campos da tabela
            builder.Property(i => i.IdItemPedido)
                .HasColumnName("IdItemPedido")
                .IsRequired(); //IsRequired => Iten obrigatório

            builder.Property(i => i.IdPedido)
                .HasColumnName("IdPedido")
                .IsRequired();

            builder.Property(i => i.IdProduto)
                .HasColumnName("IdProduto")
                .IsRequired();

            builder.Property(i => i.QuantidadeProduto)
                .HasColumnName("QuantidadeProduto")
                .IsRequired();
                
            builder.Property(i => i.ValorUnitarioProduto)
                .HasColumnName("ValorUnitarioProduto")
                .IsRequired();

            builder.Property(i => i.ValorTotalItem)
                .HasColumnName("ValorTotalItem")
                .IsRequired();

            //Mapeamento de relacionamento
            builder.HasOne(i => i.Pedido) //Todo item pertence a 1 pedido
                .WithMany(p => p.ItensPedido) //1 pedido por ter muitos itens
                .HasForeignKey(i => i.IdPedido); //chave estrangeira (Id do pedido)

            //Mapeamento de relacionamento
            builder.HasOne(i => i.Produto) //Todo item de pedido possui 1 produto
                .WithMany(p => p.ItensPedido) //produto pode ter muitos itens
                .HasForeignKey(i => i.IdProduto); //chave estrangeira (Id do produto) builder.ToTable("ENDERECO");

        }
    }
}