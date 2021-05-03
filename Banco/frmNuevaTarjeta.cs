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
    public partial class frmNuevaTarjeta : Form {
        public string dniUser { get; set; }
        private controladoraBanco control;
        public frmNuevaTarjeta() {
            InitializeComponent();
            control = new controladoraBanco();
            comboBox1.Items.Add("Débito");
            comboBox1.Items.Add("Crédito");
            comboBox1.SelectedIndex = -1;
            textBox1.Text = "0";
        }
        private void button1_Click(object sender, EventArgs e) {
            if (comboBox1.SelectedIndex != -1) {
                MessageBox.Show(control.abrirCuenta(dniUser, comboBox1.SelectedItem.ToString(),Convert.ToDecimal(textBox1.Text)));
                frmDatosTarjeta x = new frmDatosTarjeta();
                x.textBox2.Text = "Nro de Tarjeta: " + ((control.getUser(dniUser)).tarjetas.ElementAt(control.getUser(dniUser).tarjetas.Count()-1).nroTarjeta).ToString();
                x.textBox3.Text = "Nro de Cuenta: " + ((control.getUser(dniUser)).tarjetas.ElementAt(control.getUser(dniUser).tarjetas.Count()-1).nroCuenta).ToString();
                x.Show();
                Close();
            } else {
                MessageBox.Show("Seleccione algun tipo de tarjeta");
            }
        }
        private void button2_Click(object sender, EventArgs e) {
            Close();
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e) {
            if (Char.IsDigit(e.KeyChar)) {
                e.Handled = false;
            } else if (Char.IsControl(e.KeyChar)) {
                e.Handled = false;
            } else {
                e.Handled = true;
            }
        }
    }
}
