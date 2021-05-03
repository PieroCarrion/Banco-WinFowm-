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
    public partial class frmAbrirCuenta : Form {
        private controladoraBanco control;
        public string dniUsuario { get; set; }
        public frmAbrirCuenta() {
            InitializeComponent();
            control = new controladoraBanco();
            comboBox1.Items.Add("CASADO");
            comboBox1.Items.Add("SOLTERO");
            comboBox1.SelectedIndex = -1;
        }
        void clean() {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            comboBox1.SelectedIndex = -1;
        }
        private void button2_Click(object sender, EventArgs e) {
            Close();
        }
        private void button1_Click(object sender, EventArgs e) {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && comboBox1.SelectedIndex != -1) {
                if (Convert.ToInt32(numericUpDown1.Value) >= 18) {
                    if (!control.existeUsuario(textBox1.Text)) {
                        eUsuario userT = new eUsuario {
                            DNI = textBox1.Text,
                            nombre = textBox2.Text,
                            apPaterno = textBox3.Text,
                            apMaterno = textBox4.Text,
                            edad = Convert.ToInt32(numericUpDown1.Value),
                            ocupacion = textBox5.Text,
                            estado = comboBox1.SelectedItem.ToString()
                        };
                        dniUsuario = userT.DNI;
                        if (control.registrarseEnBanco(userT)) {
                            string result = "Registro exitoso" + Environment.NewLine + 
                                "Su contraseña es : " + control.getUser(userT.DNI).contraseña;
                            MessageBox.Show(result);
                            frmNuevaTarjeta aux = new frmNuevaTarjeta();
                            aux.dniUser = dniUsuario;
                            aux.ShowDialog();
                            Close();
                        } else {
                            MessageBox.Show("Vuelva a intentarlo más tarde");
                        }
                    } else {
                        MessageBox.Show("El usuario ya existe");
                    }
                } else {
                    MessageBox.Show("Ingrese una edad valida");
                }
            } else {
                MessageBox.Show("Complete los espacios en blanco");
            }
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

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e) {
            if (Char.IsLetter(e.KeyChar)) {
                e.Handled = false;
            }else if (Char.IsControl(e.KeyChar)) {
                e.Handled = false;
            }else {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e) {
            if (Char.IsLetter(e.KeyChar)) {
                e.Handled = false;
            } else if (Char.IsControl(e.KeyChar)) {
                e.Handled = false;
            } else {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e) {
            if (Char.IsLetter(e.KeyChar)) {
                e.Handled = false;
            } else if (Char.IsControl(e.KeyChar)) {
                e.Handled = false;
            } else {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e) {
            if (Char.IsLetter(e.KeyChar)) {
                e.Handled = false;
            } else if (Char.IsControl(e.KeyChar)) {
                e.Handled = false;
            } else {
                e.Handled = true;
            }
        }
    }
}
