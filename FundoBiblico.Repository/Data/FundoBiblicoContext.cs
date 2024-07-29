using FundoBiblico.Dominio.Entities;
using FundoBiblico.Dominio.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class FundoBiblicoContext : IdentityDbContext
{
    public FundoBiblicoContext(DbContextOptions<FundoBiblicoContext> options) : base(options) { }

    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Igreja> Igrejas { get; set; }
    public DbSet<Compra> Compras { get; set; }
    public DbSet<IgrejaProduto> IgrejaProdutos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(FundoBiblicoContext).Assembly);
    }
}
