using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionID { get; set; }

        public Guid TransactionCode { get; set; }

        public int CustomerID { get; set; }

        public int UserID { get; set; }
        
        [DataType(DataType.DateTime)]
        public DateTime TransactionDate { get; set; } = DateTime.Now;

        [MaxLength(100)]
        [Required]
        public string Description { get; set; }

        [Required]
        public TransactionType TransactionType { get; set; }

        [MaxLength(500)]
        public string Notes { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }

        public virtual User User { get; set; }

        public virtual Account Account { get; set; }
    }

    public enum TransactionType
    {
        Purchase,
        Expense,
        Withdrawal,
        Adjustment
    }
}
