using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Login
    {
        public int LoginId { get; set; }

        [StringLength(100, MinimumLength = 5, ErrorMessage = "Nombre de usuario demasiado corto, longitud mínima {0} caracteres")]
        [Index(IsUnique = true)]
        public string Username { get; set; }

        [MinLength(4, ErrorMessage = "Contraseña demasiada corta, longitud mínima {0} caracteres")]
        public string Password { get; set; }

        public ICollection<Manager> Managers { get; set; }

        public  ICollection<Customer> Customers { get; set; }
    }
}
