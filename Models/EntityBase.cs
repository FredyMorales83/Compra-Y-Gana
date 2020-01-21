using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class EntityBase : SharedBase
    {
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

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(100)]
        public string Nickname { get; set; }
    }
}
