using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class User : SharedBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }

        [Required]
        public string Name { get; set; }

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

        [StringLength(50, MinimumLength = 6, ErrorMessage = "El correo debe tener entre {1} y {0} caracteres")]
        public string Email { get; set; }

        [MaxLength(50)]
        public string Alias { get; set; }

        [StringLength(100, MinimumLength = 5, ErrorMessage = "Nombre de usuario demasiado corto, longitud mínima {0} caracteres")]
        [Index(IsUnique = true)]
        public string Username { get; set; }

        [MinLength(4, ErrorMessage = "Contraseña demasiada corta, longitud mínima {0} caracteres")]
        public string Password { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }

        public override string ToString()
        {
            return string.Format($"{Name} {PaternalLastname} {MaternalLastname}"); ; 
        }
    }
}