using API_Desafio_Angular.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_Desafio_Angular.Mappings
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto"); //nome da tabela

            builder.HasKey(p => p.IdProduto); //chave primária

            //demais campos da tabela

            builder.Property(p => p.IdProduto)
                .HasColumnName("IdProduto")
                .IsRequired();

            builder.Property(p => p.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(p => p.Preco)
                .HasColumnName("Preco")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(p => p.Quantidade)
                .HasColumnName("Quantidade")
                .IsRequired();

            builder.Property(p => p.UnidadeMedida )
                .HasColumnName("UnidadeMedida")
                .IsRequired();

            builder.Property(p => p.Foto)
                .HasColumnName("Foto")
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}