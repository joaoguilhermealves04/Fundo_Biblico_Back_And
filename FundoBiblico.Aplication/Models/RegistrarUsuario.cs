using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundoBiblico.Aplication.Models
{
    public class RegistrarUsuario
    {
        [Required]
        public string NomeUsuario { get; set; }
        [EmailAddress]
        public  string Email { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "The{0}must be at least {2} and at max " +
        "{1} characters long.", MinimumLength = 10)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
