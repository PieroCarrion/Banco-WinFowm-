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
    
    public partial class frmUsuario : Form {
        private controladoraBanco control;    
        public frmUsuario() {
            InitializeComponent();
            control = new controladoraBanco();
        }
        private void button2_Click(object sender, EventArgs e) {
            frmAbrirCuenta x = new frmAbrirCuenta();
            x.ShowDialog();
        }

        private void textBox2_TextChanged(object sender, EventArgs e) {
            if (textBox2.Text.Count() == 6 ) {
                if (textBox1.Text.Count() == 8) {
                    if (control.existeUsuario(textBox1.Text)) {
                        if (control.getUser(textBox1.Text).contraseña == textBox2.Text) {
                            eUsuario user = control.getUser(textBox1.Text);
                            frmUsuarioSesion x = new frmUsuarioSesion();
                            x.dniUser = textBox1.Text;
                            x.label1.Text = "Nombre";
                            x.textBox1.Text = user.nombre;
                            x.label2.Text = "Apellido Paterno";
                            x.textBox2.Text = user.apPaterno;
                            x.label3.Text = "Apellido Materno";
                            x.textBox3.Text = user.apMaterno;
                            x.label4.Text = "Nro de Tarjetas";
                            x.label5.Text = "Saldo Tarjetas";
                            decimal saldo = 0;
                            if (control.getUser(x.dniUser).tarjetas != null) {
                                foreach (eTarjeta j in control.getUser(x.dniUser).tarjetas) {
                                    saldo += j.saldoTarjeta;
                                }
                            }
                            x.textBox5.Text = saldo.ToString()+ ".00";
                            if (user.tarjetas == null) {
                                x.textBox4.Text = "0";
                            } else {
                                x.textBox4.Text = user.tarjetas.Count().ToString();
                            }
                            x.ShowDialog();
                        } else {
                            MessageBox.Show("Contraseña incorrecta");
                            textBox2.Clear();
                        }
                    } else {
                        MessageBox.Show("El usuario no existe");
                    }
                }
            }
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e) {
            if (Char.IsDigit(e.KeyChar)) {
                e.Handled = false;
            } else if (Char.IsControl(e.KeyChar)) {
                e.Handled = false;
            } else {
                e.Handled = true;
            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e) {
            if (Char.IsDigit(e.KeyChar)) {
                e.Handled = false;
            }else if (Char.IsControl(e.KeyChar)) {
                e.Handled = false;
            } else {
                e.Handled = true;
            }
        }
        private void button3_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
