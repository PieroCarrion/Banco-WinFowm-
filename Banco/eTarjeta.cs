using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco {
    public class eTarjeta {
        public string nroTarjeta { get; set; }
        public string nroCuenta { get; set; }
        public string tipoTarjeta { get; set; }  //Credito o Debito
        public string estado { get; set; }  // ACTIVA o CERRADA
        public decimal saldoTarjeta { get; set; }
    }
}
