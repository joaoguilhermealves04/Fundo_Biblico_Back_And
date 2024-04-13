using FundoBiblico.Dominio.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class IgrejaProdutoConfiguration : IEntityTypeConfiguration<IgrejaProduto>
{
    public void Configure(EntityTypeBuilder<IgrejaProduto> builder)
    {
        builder.ToTable("IgrejaProduto");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.DataCadastro)
               .HasColumnName("DataCadastro");

        builder.Property(c => c.Quantidade)
             .HasColumnName("Quantidade");

        //RELACIONAMENTO
        builder.HasOne(pd => pd.Igreja)
               .WithMany(v => v.IgrejaProdutos)
               .HasForeignKey(pd => pd.IgrejaId);

        builder.HasOne(pd => pd.Produto)
               .WithMany(v => v.IgrejaProdutos)
               .HasForeignKey(pd => pd.ProdutoId);
    }
}
