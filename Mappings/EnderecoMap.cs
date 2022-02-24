using API_Desafio_Angular.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_Desafio_Angular.Mappings
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Endereco> builder)
        {
             builder.ToTable("endereco");//nome da tabela

            builder.HasKey(e => e.IdEndereco); //chave primária

            builder.Property(e => e.IdEndereco)
                .HasColumnName("IdEndereco");

            builder.Property(e => e.Logradouro)
                .HasColumnName("Logradouro")
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(e => e.Numero)
                .HasColumnName("Numero")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(e => e.Complemento)
                .HasColumnName("Complemento")
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(e => e.Bairro)
                .HasColumnName("Bairro")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(e => e.Cidade)
                .HasColumnName("Cidade")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(e => e.Estado)
                .HasColumnName("Estado")
                .HasMaxLength(25)
                .IsRequired();

            builder.Property(e => e.Cep)
                .HasColumnName("Cep")
                .HasMaxLength(8)
                .IsRequired();

            builder.Property(e => e.IdCliente)
                .HasColumnName("IdCliente")
                .IsRequired();

            //Mapeamento de relacionamentos
            //Endereco PERTENCE a 1 Cliente
            //Cliente POSSUI muitos Enderecos
            builder.HasOne(e => e.Cliente) //Endereco TEM 1 Cliente
                .WithMany(c => c.Enderecos) //Cliente TEM MUITOS Enderecos
                .HasForeignKey(e => e.IdCliente); //Chave estrangeira
        }
    }
}