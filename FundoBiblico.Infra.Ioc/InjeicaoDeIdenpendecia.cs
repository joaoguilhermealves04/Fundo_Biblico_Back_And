using FundoBiblico.Aplication.Helper;
using FundoBiblico.Aplication.IServicos;
using FundoBiblico.Aplication.Servicos;
using FundoBiblico.Dominio.Interfaces;
using FundoBiblico.Dominio.Interfaces.RepositoryBase;
using FundoBiblico.Repository.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundoBiblico.Infra.Ioc
{
    public static class InjeicaoDeIdenpendecia
    {
        public static IServiceCollection AddInfrastuctureAPi(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FundoBiblicoContext>
                (options => options.UseSqlServer(ConnectionStringHelper.Conexao()));

            // Repositorios 
            services.AddScoped<IClienteRepositroy, ClienteRepository>();
            services.AddScoped<IIgrejaRepository, IgrejaRepository>();
            //services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            // Serviços
            services.AddScoped<IClienteServicos, ClienteServicos>();
            services.AddScoped<IIgrejaServicos, IgrejaServicos>();

            // Validações 
            services.AddScoped<ValidacaoDosDadosHelper>();

            return services;
        }
    }
}
