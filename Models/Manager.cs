using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Manager : EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ManagerID { get; set; }        

        [StringLength(100, MinimumLength = 5, ErrorMessage = "Nombre de usuario demasiado corto, longitud mínima {0} caracteres")]
        [Index(IsUnique = true)]
        public string Username { get; set; }

        [MinLength(4, ErrorMessage = "Contraseña demasiada corta, longitud mínima {0} caracteres")]
        public string Password { get; set; }
        
        [Required]
        public Login Login { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }

        public override string ToString()
        {
            return string.Format($"{Name} {PaternalLastname} {MaternalLastname}"); ; 
        }
    }
}