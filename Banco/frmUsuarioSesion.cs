using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banco {
    public partial class frmUsuarioSesion : Form {
        public string dniUser { get; set; }
        public frmUsuarioSesion() {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e) {
            Close();
        }

        private void btnSolicitudes_Click(object sender, EventArgs e) {
            frmSolicitud x = new frmSolicitud();
            x.dniUsuario = dniUser;
            x.Show();
        }
        private void btnNuevaCuenta_Click(object sender, EventArgs e) {
            frmNuevaTarjeta x = new frmNuevaTarjeta();
            x.dniUser = dniUser;
            x.Show();
        }
        private void btnEstado_Click(object sender, EventArgs e) {
            frmEstadoPrestamo x = new frmEstadoPrestamo();
            x.dniUser = dniUser;
            x.Show();
        }
    }
}
