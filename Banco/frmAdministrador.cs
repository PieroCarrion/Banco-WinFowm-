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
    public partial class frmAdministrador : Form {
        private controladoraBanco control;
        public frmAdministrador() {
            InitializeComponent();
            control = new controladoraBanco();
        }

        private void button1_Click(object sender, EventArgs e) {
            if (controladoraBanco.listaUsuarios != null && controladoraBanco.listaUsuarios.Count() != 0) {
                frmEvaluarSolicitudes x = new frmEvaluarSolicitudes();
                x.Show();
            } else {
                MessageBox.Show("No hay datos");
            }
        }
        private void button2_Click(object sender, EventArgs e) {
            frmTodosLosUsuarios x = new frmTodosLosUsuarios();
            x.Show();
        }
        private void button3_Click(object sender, EventArgs e) {
            if (controladoraBanco.listaUsuarios != null) {
                if (controladoraBanco.listaUsuarios.Count != 0) {
                    decimal monto = 0;
                    foreach (eUsuario user in controladoraBanco.listaUsuarios) {
                        if (user.listaPrestamos != null) {
                            foreach (ePrestamo prestamo in user.listaPrestamos) {
                                monto += prestamo.montoSolicitado;
                            }
                        }
                    }
                    MessageBox.Show("La deuda de todos los usuarios es: " + monto);
                } else {
                    MessageBox.Show("No hay usuarios");
                }
            }
        }
        private void button4_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
