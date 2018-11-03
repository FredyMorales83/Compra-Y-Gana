using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Account : SharedBase
    {
        [Key, ForeignKey("Customer")]
        public int CustomerID { get; set; }

        public DateTime? DateClosed { get; set; }

        public decimal CurrentPointsBalance { get; set; }

        public bool Active { get; set; } = true;

        [NotMapped]
        public decimal CurrentMoneyBalance { get { return CurrentPointsBalance * 0.1m ; } }

        public virtual Customer Customer { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
