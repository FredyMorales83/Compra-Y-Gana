using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class AccountDetailsViewModel
    {
        public string CustomerFullname { get; set; }
        public string AccountNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ActualPeriod { get; set; }
        public decimal AccumulatedPoints { get; set; }
        public decimal CashEquivalent { get; set; }
        public IEnumerable<Transaction> Transactions { get; set; }
    }
}
