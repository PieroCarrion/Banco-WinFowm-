using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco {
    public class eSolicitudes {
        public int idSolicitud { get; set; }
        public ePrestamo prestamoDatos { get; set; }
        public string resultado { get; set; } // aprobado = 1, desaprobado = 0
    }
}
