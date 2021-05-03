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
    public partial class frmSolicitarPrestamo : Form {
        private controladoraBanco control;
        public string dniUser;
        public frmSolicitarPrestamo() {
            InitializeComponent();
            control = new controladoraBanco();
            textBox3.Text = DateTime.Now.Date.Date.ToShortDateString().ToString();
        }

        private void button1_Click(object sender, EventArgs e) {
            if (textBox1.Text != "" && textBox2.Text != "" && comboBox1.SelectedIndex != -1 && (radioButton1.Checked != false || radioButton2.Checked != false || radioButton3.Checked != false)) {
                int cantCuotas = 0;
                if (radioButton1.Checked) {
                    cantCuotas = 6;
                }
                else if(radioButton2.Checked){
                    cantCuotas = 12;
                }
                else if (radioButton3.Checked) {
                    cantCuotas = 18;
                }
                ePrestamo prestamo = new ePrestamo {
                    DNIcliente = dniUser,
                    montoSolicitado = Convert.ToDecimal(textBox1.Text),
                    nroDeCuenta = comboBox1.SelectedItem.ToString(),
                    cuotasxPagar = cantCuotas,
                    fechaDeSolicitud = textBox3.Text,
                    descripcion = textBox2.Text
                  };
                //
                eUsuario user = controladoraBanco.listaUsuarios.Find(delegate (eUsuario value) { return value.DNI == dniUser; });
                decimal montoAux = 0;
                if (user.listaPrestamos != null) {
                    foreach (ePrestamo auxE in user.listaPrestamos) {
                        montoAux += auxE.montoSolicitado;
                    }
                }
                string result = "";
                if (user.edad <= 60) {
                    if (montoAux <= 50000) {
                        control.solicitarPrestamo(prestamo);
                        result = "Operacion Realizada con Exito";
                    } else {
                        result = "Usted ha superado su monto maximo de Prestamo";
                    }
                } else if (user.edad > 60 && user.edad < 78) {
                    if (montoAux <= 19000) {

                        control.solicitarPrestamo(prestamo);
                        result = "Operacion Realizada con Exito";
                    } else {
                        result = "Usted ha superado su monto maximo de Prestamo";
                    }
                } else if (user.edad >= 78) {
                    if (montoAux <= 2000) {

                        control.solicitarPrestamo(prestamo);
                        result = "Operacion Realizada con Exito";
                    } else {
                        result = "Usted ha superado su monto maximo de Prestamo";
                    }
                }
                MessageBox.Show(result);
                Close();
            } else {
                MessageBox.Show("Complete los espacios en blanco");
            }
        }
        private void button2_Click(object sender, EventArgs e) {
            Close();
        }
        private void button1_KeyPress(object sender, KeyPressEventArgs e) {
            if (Char.IsDigit(e.KeyChar)) {
                e.Handled = false;
            } else if (Char.IsControl(e.KeyChar)) {
                e.Handled = false;
            } else {
                e.Handled = true;
            }
        }
        private void frmSolicitarPrestamo_Load(object sender, EventArgs e) {
            if (control.getUser(dniUser).tarjetas.Count() > 0) {
                foreach (eTarjeta tarjeta in control.getUser(dniUser).tarjetas) {
                    comboBox1.Items.Add(tarjeta.nroCuenta);
                }
            }
            comboBox1.SelectedIndex = -1;
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e) {
            if (Char.IsDigit(e.KeyChar)) {
                e.Handled = false;
            }else if (Char.IsControl(e.KeyChar)) {
                e.Handled = false;
            }else {
                e.Handled = true;
            }
        }
    }
}
