using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Customer : SharedBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Names { get; set; }

        [Required]
        [MaxLength(50)]
        public string PaternalLastname { get; set; }

        [MaxLength(50)]
        public string MaternalLastname { get; set; }

        [StringLength(300, ErrorMessage = "La longitud máxima de la dirección son de {0} caracteres")]
        public string Address { get; set; }

        [MaxLength(10)]
        public string Phone { get; set; }
        
        [MaxLength(10)]
        public string Cellphone { get; set; }
        
        [StringLength(50, ErrorMessage = "Longitud máxima del correo debe es {0} caracteres")]
        public string Email { get; set; }

        [MaxLength(100)]
        public string Nickname { get; set; }

        [MinLength(5,ErrorMessage = "Nombre de usuario demasiado corto, longitud mínima {0} caracteres")]
        [MaxLength(100), Index(IsUnique = true)]
        public string Username { get; set; }

        [StringLength(32, MinimumLength = 4, ErrorMessage = "Contraseña demasiada corta, longitud mínima {0} caracteres")]
        public string Password { get; set; }

        public virtual Account Account { get; set; }

        public override string ToString()
        {
            return string.Format($"{Names} {PaternalLastname} {MaternalLastname}");
        }
    }
}
