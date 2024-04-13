using FundoBiblico.Dominio.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        { 
            builder.ToTable("Cliente");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                   .HasColumnName("Nome")
                   .IsRequired();

            builder.Property(c => c.DataCadastro)
                   .HasColumnName("DataCadastro");
        }
    }

