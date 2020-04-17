using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class TransactionViewModel
    {
        public int ID { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public string Transaccion { get; set; }
        public string Monto { get; set; }
        public string Notas { get; set; }
    }
}
