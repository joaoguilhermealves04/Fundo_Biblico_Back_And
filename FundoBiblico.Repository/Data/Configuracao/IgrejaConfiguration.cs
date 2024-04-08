using FundoBiblico.Dominio.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundoBiblico.Repository.Data.Configuracao
{
    public class IgrejaConfiguration : IEntityTypeConfiguration<Igreja>
    {
        public void Configure(EntityTypeBuilder<Igreja> builder)
        {
            builder.ToTable("Igrejas");
            builder.HasKey(i => i.Id);
            builder.Property(i => i.DataCadastro).IsRequired();
        }
    }
}
