using FundoBiblico.Dominio.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.ToTable("Produto");
        builder.HasKey(p => p.Id);

        builder.Property(i => i.Nome)
               .HasColumnName("Nome");

        builder.Property(i => i.Descricao)
               .HasColumnName("Descricao");

        builder.Property(i => i.Foto)
               .HasColumnName("Foto");

        builder.Property(i => i.Preco)
               .HasColumnName("Preco");

        builder.Property(i => i.QuantidadeEstoque)
               .HasColumnName("QuantidadeEstoque");

        builder.Property(p => p.DataCadastro)
               .HasColumnName("DataCadastro");
    }
}
