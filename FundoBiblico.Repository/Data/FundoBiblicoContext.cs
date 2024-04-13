using FundoBiblico.Dominio.Entities;
using FundoBiblico.Dominio.Entity;
using Microsoft.EntityFrameworkCore;

public class FundoBiblicoContext : DbContext
{

    public FundoBiblicoContext(DbContextOptions<FundoBiblicoContext> options) : base(options) { }

    private FundoBiblicoContext() { }

    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Igreja> Igrejas { get; set; }
    public DbSet<Compra> Compras { get; set; }
    public DbSet <IgrejaProduto> igrejaProdutos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(FundoBiblicoContext).Assembly);
    }
}
