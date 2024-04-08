using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundoBiblico.Infra.Ioc
{
    public class ConnectionStringHelper
    {
        public static string Conexao ()
        {
            IConfiguration configuration  = new ConfigurationBuilder()
                .SetBasePath (Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build ();

            return configuration.GetConnectionString("conexao");
        }
    }
}
