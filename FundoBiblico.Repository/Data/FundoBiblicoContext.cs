using FundoBiblico.Dominio.Entities;
using FundoBiblico.Dominio.Entity;
using FundoBiblico.Repository.Data.Configuracao;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace FundoBiblico.Repository.Data
{
    public class FundoBiblicoContext : DbContext
    {
        // Define as tabelas do banco de dados como propriedades DbSet
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Igreja> Igrejas { get; set; }
        public DbSet<Compra> Compras { get; set; }

        public FundoBiblicoContext(DbContextOptions<FundoBiblicoContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FundoBiblicoContext).Assembly);
        }
    }
}