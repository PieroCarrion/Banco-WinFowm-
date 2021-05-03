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
    public partial class frmEvaluarSolicitudes : Form {
        public List<eSolicitudes> solicitudes;
        private eSolicitudes solAux;
        public frmEvaluarSolicitudes() {
            InitializeComponent();
            solicitudes = new List<eSolicitudes>();
            if (controladoraBanco.listaUsuarios.Count != 0) {
                foreach (eUsuario usuario in controladoraBanco.listaUsuarios) {
                    if (usuario.solicitudes != null) {
                        foreach (eSolicitudes solicitud in usuario.solicitudes) {
                            if (solicitud.resultado == "EN PROCESO") {
                                solicitudes.Add(solicitud);
                            }
                        }
                    }
                }
                if (solicitudes.Count != 0) {
                    listBox1.DataSource = solicitudes;
                    listBox1.ValueMember = "idSolicitud";
                    listBox1.DisplayMember = "idSolicitud";
                    listBox1.SelectedIndex = -1;
                }
            } else {
                MessageBox.Show("No hay usuarios");
                Close();
            }
            comboBox1.Items.Add("APROBADO");
            comboBox1.Items.Add("DESAPROBADO");
            listBox1.SelectedIndex = -1;
        }
        private void frmEvaluarSolicitudes_Load(object sender, EventArgs e) {
            listBox1.SelectedIndex = -1;
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {
            if (listBox1.SelectedIndex != -1) {
                solAux = listBox1.SelectedItem as eSolicitudes;
                textBox1.Text = solAux.prestamoDatos.DNIcliente;
                textBox2.Text = solAux.idSolicitud.ToString();
                textBox3.Text = solAux.prestamoDatos.montoSolicitado.ToString();
                textBox4.Text = solAux.prestamoDatos.nroDeCuenta.ToString();
                textBox5.Text = solAux.prestamoDatos.fechaDeSolicitud;
                textBox6.Text = solAux.prestamoDatos.descripcion;
            }
        }
        private void button1_Click(object sender, EventArgs e) {
            if (comboBox1.SelectedIndex != -1) {
                eUsuario user = controladoraBanco.listaUsuarios.Find(delegate(eUsuario value) { return value.DNI == solAux.prestamoDatos.DNIcliente; });
                if (user.solicitudes != null) {
                    eSolicitudes temp = user.solicitudes.Find(delegate(eSolicitudes value) { return value.idSolicitud == solAux.idSolicitud; });
                    temp.resultado = comboBox1.SelectedItem.ToString();
                    if (temp.resultado == "APROBADO") {
                        if (user.listaPrestamos == null) {
                            user.listaPrestamos = new List<ePrestamo>();
                        }
                        eTarjeta aux = user.tarjetas.Find(delegate (eTarjeta value) { return value.nroCuenta == solAux.prestamoDatos.nroDeCuenta; });
                        aux.saldoTarjeta += Convert.ToDecimal(solAux.prestamoDatos.montoSolicitado);
                        user.listaPrestamos.Add(solAux.prestamoDatos);
                    }
                    MessageBox.Show("Autorizado");
                    Close();
                }
            } else {
                MessageBox.Show("Seleccione una Aprobado o Desaprobado");
            }
        }
    }
}
