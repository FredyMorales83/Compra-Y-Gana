using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class AccountDetailsViewModel
    {
        [DisplayName("Cliente: ")]
        public string CustomerFullname { get; set; }
        [DisplayName("Número de cuenta: ")]
        public string AccountNumber { get; set; }
        [DisplayName("Correo electrónico: ")]
        public string Email { get; set; }
        [DisplayName("Dirección: ")]
        public string Address { get; set; }
        [DisplayName("Periodo actual: ")]
        public string ActualPeriod { get; set; }
        [DisplayName("Puntos acumulados: ")]
        public decimal AccumulatedPoints { get; set; }
        [DisplayName("Dinero electrónico: ")]
        public decimal CashEquivalent { get; set; }
        public IEnumerable<Transaction> Transactions { get; set; }
    }
}
