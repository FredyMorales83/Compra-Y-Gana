using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Fecha")]
        public DateTime TransactionDate { get; set; } = DateTime.Now;

        [MaxLength(100)]
        [Required]
        [DisplayName("Descripción")]
        public string Description { get; set; }

        [Required]
        [DisplayName("Transacción")]
        public TransactionType TransactionType { get; set; }

        [MaxLength(500)]
        public string Notes { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [DisplayName("Monto")]
        public decimal Amount { get; set; }

        public virtual Manager User { get; set; }

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
