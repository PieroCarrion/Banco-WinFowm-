    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco {
    public class ePrestamo {
        public int idPrestamo { get; set; }
        public string DNIcliente { get; set; }
        public decimal montoSolicitado { get; set; }
        public string nroDeCuenta { get; set; } // A realizar el deposito
        public int cuotasxPagar { get; set; } // cuotas de 6, 12 , 18 meses
        public string fechaDeSolicitud { get; set; }
        public string descripcion { get; set; }
    }
}
