using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundoBiblico.Aplication.Models
{
    public class LoginUsuario
    {
        [Required(ErrorMessage = "Nome de Usuario não esta correto ou não existe.")]
        public string NomeUsuario { get; set; }
        [Required(ErrorMessage = "A senhar esta incorreta, Digite novamente.")]
        [StringLength(20, ErrorMessage = "The{0}must be at least {2} and at max " +
        "{1} characters long.", MinimumLength = 10)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public class LoginReponseViewModel
    {
        public string AccessToken { get; set; }
        public double ExpiresIn { get; set; }
        public UserTokenViewModel UserToken { get; set; }
    }

    public class UserTokenViewModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
    }
}
