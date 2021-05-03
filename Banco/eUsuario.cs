using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco {
    public class eUsuario {
        public string DNI { get; set; }
        public string nombre { get; set; }
        public string estado { get; set; }
        public int edad { get; set; }
        public string ocupacion { get; set; }
        public string apPaterno { get; set; }
        public string apMaterno { get; set; }
        public string contraseña { get; set; }
        public List<eTarjeta> tarjetas { get; set; } 
        public List<eSolicitudes> solicitudes { get; set; } //solicitudes rechazas y aprobadas
        public List<ePrestamo> listaPrestamos { get; set; } // prestamos aprobados
    }
}
