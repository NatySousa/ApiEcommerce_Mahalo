using API_Desafio_Angular.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_Desafio_Angular.Mappings //mapeamento no Entityframework
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente> // vai mapear a classe cliente
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Cliente> builder)
        {
           builder.ToTable("cliente"); //nome da tabela
           
           builder.HasKey(c => c.IdCliente); //chave primária

            // Demais campos da tabela

            builder.Property(c => c.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(150)
                .IsRequired();


            builder.Property(c => c.Cpf)
                .HasColumnName("Cpf")
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(c => c.Email)
                .HasColumnName("Email")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Senha)
                .HasColumnName("Senha")
                .HasMaxLength(50)
                .IsRequired();

            //Mapeamento de índices => Definir campos únicos (UNIQUE) na tabela

            builder.HasIndex(c => c.Cpf)
                .IsUnique(true);

            builder.HasIndex(c => c.Email)
                .IsUnique(true);

        }
    }
}