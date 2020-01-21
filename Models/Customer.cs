using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Customer : EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerID { get; set; }        

        [MinLength(5,ErrorMessage = "Nombre de usuario demasiado corto, longitud mínima {0} caracteres")]
        [MaxLength(100), Index(IsUnique = true)]
        public string Username { get; set; }

        [StringLength(32, MinimumLength = 4, ErrorMessage = "Contraseña demasiada corta, longitud mínima {0} caracteres")]
        public string Password { get; set; }

        public virtual Account Account { get; set; }

        public Login Login { get; set; }

        public override string ToString()
        {
            return string.Format($"{Name} {PaternalLastname} {MaternalLastname}");
        }
    }
}
