using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administrativo.Repository.Data
{
    public class AdministrativoContexto : IdentityDbContext
    {
        public AdministrativoContexto(DbContextOptions options) : base(options)
        {
        }
    }
}
