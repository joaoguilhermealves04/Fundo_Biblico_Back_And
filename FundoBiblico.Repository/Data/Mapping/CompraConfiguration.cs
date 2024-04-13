using FundoBiblico.Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CompraConfiguration : IEntityTypeConfiguration<Compra>
{
    public void Configure(EntityTypeBuilder<Compra> builder)
    {
        builder.ToTable("Compra");
        builder.HasKey(c => c.Id);

        builder.Property(c => c.DataCadastro)
               .HasColumnName("DataCadastro");

        builder.Property(i => i.ValorProduto)
               .HasColumnName("ValorProduto");

        builder.Property(i => i.DataCompra)
               .HasColumnName("DataCompra");

        builder.Property(i => i.Quantidade)
               .HasColumnName("Quantidade");

        //RELACIONAMENTO
        builder.HasOne(pd => pd.Cliente)
            .WithMany(v => v.Compras)
            .HasForeignKey(pd => pd.ClienteId);

        builder.HasOne(pd => pd.igreja)
            .WithMany(v => v.Compras)
            .HasForeignKey(pd => pd.IgrejaId);

        builder.HasOne(pd => pd.Produto)
            .WithMany(v => v.Compras)
            .HasForeignKey(pd => pd.ProdutoId);
    }
}
