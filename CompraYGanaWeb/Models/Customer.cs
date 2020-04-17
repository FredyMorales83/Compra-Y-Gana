using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompraYGanaWeb.Models
{
    public class Customer : EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerID { get; set; }

        public virtual Account Account { get; set; }

        public Login Login { get; set; }

        public override string ToString()
        {
            return string.Format($"{Name} {PaternalLastname} {MaternalLastname}");
        }
    }
}
