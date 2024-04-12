using FundoBiblico.Dominio.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundoBiblico.Repository.Data.Configuracao
{
    internal class IgrejaProdutoConfiguration : IEntityTypeConfiguration<IgrejaProduto>
    {

        public void Configure(EntityTypeBuilder<IgrejaProduto> builder)
        {
            builder.ToTable("IgrejaProdutos");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.DataCadastro).IsRequired();
        }

    }
}
