using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompraYGanaWeb.Models
{
    public class Manager : EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ManagerID { get; set; }
        
        [Required]
        public Login Login { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }

        public override string ToString()
        {
            return string.Format($"{Name} {PaternalLastname} {MaternalLastname}"); ; 
        }
    }
}