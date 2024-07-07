using Administrativo.Repository.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundoBiblico.Infra.Ioc
{
    public static class IdentityConfiguration
    {
        public static IServiceCollection IdentityInfraConfiguration(this IServiceCollection services)
        {

            services.AddDbContext<AdministrativoContexto>
                (options => options.UseSqlServer(ConnectionStringHelper.Administrativo()));

            services.AddIdentity<IdentityUser, IdentityRole>()
                            .AddEntityFrameworkStores<AdministrativoContexto>()
                                .AddDefaultTokenProviders();


            return services;
        }
    }
}
