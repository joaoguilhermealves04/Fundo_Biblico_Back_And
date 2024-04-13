using FundoBiblico.Dominio.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class IgrejaConfiguration : IEntityTypeConfiguration<Igreja>
{
    public void Configure(EntityTypeBuilder<Igreja> builder)
    {
        builder.ToTable("Igreja");

        builder.HasKey(i => i.Id);

        builder.Property(i => i.Nome)
               .HasColumnName("Nome");

        builder.Property(i => i.UF)
               .HasColumnName("UF");

        builder.Property(i => i.Setor)
               .HasColumnName("Setor");

        builder.Property(i => i.DataCadastro)
               .HasColumnName("DataCadastro");
    }
}
